using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.RegularExpressions;

namespace WarehouseManagement.Application.Filters;

public class InputSanitizationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        foreach (var argument in context.ActionArguments.Values)
        {
            if (argument == null)
                continue;

            var stringProperties = argument
                .GetType()
                .GetProperties(
                    BindingFlags.Public |
                    BindingFlags.Instance)
                .Where(p =>
                    p.CanRead &&
                    p.PropertyType == typeof(string));

            foreach (var property in stringProperties)
            {
                var value = property.GetValue(argument) as string;

                if (string.IsNullOrWhiteSpace(value))
                    continue;

                if (IsPotentiallyMalicious(value))
                {
                    throw new InvalidOperationException(
                        $"ورودی نامعتبر است. Property: {property.Name}");
                }
            }
        }

        await next();
    }

    private static bool IsPotentiallyMalicious(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        var normalized = NormalizeInput(input);

        var patterns = new[]
        {
            // XSS
            @"<\s*script\b",
            @"<\s*/\s*script\s*>",
            @"on[a-z]+\s*=",
            @"javascript\s*:",
            @"vbscript\s*:",
            @"data\s*:\s*text/html",
            @"expression\s*\(",
            @"url\s*\(\s*['""]?\s*javascript\s*:",
            @"<\s*(iframe|object|embed|meta|link|base|form)\b",
            @"document\s*\.\s*(cookie|location|write)",
            @"window\s*\.\s*location",
            @"innerHTML",
            @"outerHTML",
            @"insertAdjacentHTML",
            @"eval\s*\(",
            @"new\s+Function\s*\(",

            // Command Injection
            @"\$\s*\(",
            @"`[^`]*`",
            @"\b(rm|chmod|chown|curl|wget|sudo|bash|sh|powershell|pwsh|cmd|copy|move|del)\b",

            // Path Traversal
            @"\.\.[\\/]",

            // SQL Injection patterns
            @"(--|/\*|\*/)",
            @"\bunion\s+(all\s+)?select\b",
            @"\bor\s+1\s*=\s*1\b",
            @"\band\s+1\s*=\s*1\b",
            @"\bdrop\s+(table|database)\b",
            @"\btruncate\s+table\b",
            @"\binsert\s+into\b",
            @"\bdelete\s+from\b",
            @"\bupdate\s+\w+\s+set\b",
            @"\bexec(?:ute)?\s*\(",
            @"\bxp_cmdshell\b"
        };

        return patterns.Any(pattern =>
            Regex.IsMatch(
                normalized,
                pattern,
                RegexOptions.IgnoreCase |
                RegexOptions.Singleline |
                RegexOptions.CultureInvariant |
                RegexOptions.Compiled));
    }

    private static string NormalizeInput(string input)
    {
        var normalized = input;

        try
        {
            normalized = Uri.UnescapeDataString(normalized);
        }
        catch
        {
        }

        normalized = WebUtility.HtmlDecode(normalized);

        normalized = normalized.Normalize(
            NormalizationForm.FormC);

        normalized = Regex.Replace(
            normalized,
            @"\s+",
            " ");

        return normalized.Trim();
    }
}