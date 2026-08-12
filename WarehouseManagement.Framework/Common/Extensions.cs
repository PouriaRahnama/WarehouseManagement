using Microsoft.AspNetCore.WebUtilities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;


namespace WarehouseManagement.Framework.Common;

public static class Extensions
{
    // Convert miladi to persian date
    public static string ToPersianDate(this DateTime date)
    {
        PersianCalendar pc = new PersianCalendar();
        return pc.GetYear(date) + "/" + pc.GetMonth(date).ToString("00") + "/" + pc.GetDayOfMonth(date).ToString("00");
    }
    // Convert persian date to miladi
    public static DateTime PersianToDateTime(this string persianDate)
    {
        if (persianDate.Length != 10)
        {
            throw new ArgumentException(nameof(persianDate));
        }
        PersianCalendar persian = new PersianCalendar();
        int year = Convert.ToInt32(persianDate.Substring(0, 4));
        var convertDate = persian.ToDateTime(year, Convert.ToInt32(persianDate.Substring(5, 2)), Convert.ToInt32(persianDate.Substring(8, 2)), 0, 0, 0, 0); ;

        return convertDate;
    }
    //Get User Id
    public static Guid GetUserId(this HttpContext? httpContext)
    {
        var claimsIdentity = httpContext?.User.Identity as ClaimsIdentity;
        var userIdValue = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        if (Guid.TryParse(userIdValue, out Guid userId))
        {
            return userId == Guid.Empty ? throw new UnauthorizedException("کاربر شناسایی نشد") : userId;
        }

        throw new UnauthorizedException("کاربر شناسایی نشد");
    }
    public static Tuple<long?, string?> GetUserInformation(this HttpContext? httpContext)
    {
        long? userId = null;

        var claimsIdentity = httpContext?.User.Identity as ClaimsIdentity;
        var userIdValue = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        userId = string.IsNullOrWhiteSpace(userIdValue) ? null : long.Parse(userIdValue);

        string? userIP = httpContext?.Connection?.RemoteIpAddress.ToString() ?? null;

        return new(userId, userIP);
    }
    //Get User Browser
    public static string GetUserBrowser(this HttpContext context) => context.Request.Headers["User-Agent"].ToString();
    //Get User IP
    public static string GetUserIP(this HttpContext context) => context.Connection.RemoteIpAddress.ToString();
    public async static Task<string> SaveImageAndGenerateName(IFormFile imageFile, string directoryPath)
    {
        if (imageFile == null)
            throw new InvalidDataException("file is Null");

        var allowed = new[] { ".jpg", ".jpeg", ".png", ".webp" };

        var ext = Path.GetExtension(imageFile.FileName).ToLower();

        if (!allowed.Contains(ext))
            throw new Exception("فرمت وارد شده نامعتبر است!");

        var fileName = imageFile.FileName;
        fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                          .Replace(":", "")
                          .Replace(".", "") + Path.GetExtension(fileName);

        var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
        if (!Directory.Exists(folderName))
            Directory.CreateDirectory(folderName);

        var Url = Path.Combine(folderName, fileName);

        using var stream = new FileStream(Url, FileMode.Create);
        await imageFile.CopyToAsync(stream);

        return fileName;
    }
    public async static Task<string> SaveFileAndGenerateName(IFormFile File, string directoryPath)
    {
        if (File == null)
            throw new InvalidDataException("file is Null");

        var fileName = File.FileName;
        fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                          .Replace(":", "")
                          .Replace(".", "") + Path.GetExtension(fileName);

        var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
        if (!Directory.Exists(folderName))
            Directory.CreateDirectory(folderName);

        var Url = Path.Combine(folderName, fileName);

        using var stream = new FileStream(Url, FileMode.Create);
        await File.CopyToAsync(stream);

        return fileName;
    }
    public static string GetImage(string imageName, string ServerPath, string imagePath)
    {
        ServerPath = $"https://{ServerPath}";
        return $"{ServerPath}{imagePath}/{imageName}";
    }
    public static string GetFile(string imageName, string ServerPath, string Path)
    {
        ServerPath = $"https://{ServerPath}";
        return $"{ServerPath}{Path}/{imageName}";
    }
    public static void DeleteFile(string path, string fileName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
        if (File.Exists(filePath))
            File.Delete(filePath);
    }
    public static string GetDayName(this DateTime date)
    {
        string dayOfWeekName = date.DayOfWeek.ToString();
        switch (dayOfWeekName)
        {
            case "Monday":
                dayOfWeekName = "دوشنبه";
                break;
            case "Tuesday":
                dayOfWeekName = "سه‌شنبه";
                break;
            case "Wednesday":
                dayOfWeekName = "چهارشنبه";
                break;
            case "Thursday":
                dayOfWeekName = "پنج‌شنبه";
                break;
            case "Friday":
                dayOfWeekName = "جمعه";
                break;
            case "Saturday":
                dayOfWeekName = "شنبه";
                break;
            case "Sunday":
                dayOfWeekName = "یک‌شنبه";
                break;
        }
        return dayOfWeekName;
    }
    public static string ConvertByteArrayToBase64string(this byte[] ImageBytes)
    {
        string imageBase64Data = Convert.ToBase64String(ImageBytes);
        string imgDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

        return imgDataURL;
    }
    public static byte[] ConvertIFormFileToByteforImage(IFormFile formFile)
    {
        using MemoryStream memoryStream = new MemoryStream();
        formFile.CopyTo(memoryStream);
        var imageBytes = memoryStream.ToArray();

        return imageBytes;
    }
    public static byte[] ConvertIFormFileToByteforFile(IFormFile formFile)
    {
        using MemoryStream memoryStream = new MemoryStream();
        formFile.CopyTo(memoryStream);
        var imageBytes = memoryStream.ToArray();

        return imageBytes;
    }
    public static string GetDisplayName(this Enum value)
    {
        var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();

        if (member == null)
            return value.ToString();

        var display = member.GetCustomAttribute<DisplayAttribute>();

        return display?.Name ?? value.ToString();
    }

    public static List<string> GetAllClassName(this Type type)
    {
        var _lista = new List<Assembly>(); 
        foreach (string dllPath in Directory.GetFiles(AppContext.BaseDirectory, "WarehouseManagement.*.dll"))
        {
            var shadowCopiedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);
            _lista.Add(shadowCopiedAssembly);
        }

        return _lista.SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) & !x.IsInterface & !x.IsAbstract).Select(x => x.FullName).ToList();
    }
    public static List<Type> GetAllClassTypes(this Type type)
    {
        var _lista = new List<Assembly>();
        foreach (string dllPath in Directory.GetFiles(AppContext.BaseDirectory, "WarehouseManagement.*.dll"))
        {
            var shadowCopiedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);
            _lista.Add(shadowCopiedAssembly);
        }

        return _lista.SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) & !x.IsInterface & !x.IsAbstract).ToList();

    }
    public static string GenerateProductCode(this string prefix)
    {
        return $"{prefix}-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..6].ToUpper()}";
    }
    public static string GenerateDocumentNumber(this string prefix)
    {
        return $"{prefix}-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..6].ToUpper()}";
    }
    public static string GenerateWarehoseCode(this string prefix)
    {
        return $"{prefix}-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..6].ToUpper()}";
    }
    public static bool IsPersian(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        // چک کردن وجود حداقل یک کاراکتر فارسی
        return Regex.IsMatch(input, @"[\u0600-\u06FF\u0750-\u077F\u08A0-\u08FF\uFB50-\uFDFF\uFE70-\uFEFF]");
    }
    public static string ComputeSha256(string input)
    {
        using var sha256 = SHA256.Create();

        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = sha256.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }

    public static bool VerifySha256(string input, string hash)
    {
        var inputHash = ComputeSha256(input);

        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(inputHash),
            Encoding.UTF8.GetBytes(hash));
    }


    public static string GetDeviceName(this HttpContext httpContext)
    {
        if (httpContext == null)
            return "";

        var userAgent = httpContext.Request.Headers["User-Agent"].ToString();

        if (string.IsNullOrWhiteSpace(userAgent))
            return "Unknown Device";

        return userAgent;
    }


    public static void AddWebpImageToServer(this IFormFile image, string fileName, string originalPath,
        int? width = default,
        int? height = default, string thumbPath = null, string deletefileName = null, bool checkImageContent = true)
    {
        if (image == null || string.IsNullOrEmpty(fileName)) return;

        try
        {
            // 1. آماده‌سازی مسیرهای مطلق (Absolute Paths)
            string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string targetDir = Path.Combine(root, originalPath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

            // 2. مدیریت حذف فایل‌های قدیمی
            if (!string.IsNullOrEmpty(deletefileName))
            {
                string deletePath = Path.Combine(targetDir, deletefileName);
                if (File.Exists(deletePath)) File.Delete(deletePath);

                if (!string.IsNullOrEmpty(thumbPath))
                {
                    string thumbDir = Path.Combine(root, thumbPath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                    string deleteThumbPath = Path.Combine(thumbDir, deletefileName);
                    if (File.Exists(deleteThumbPath)) File.Delete(deleteThumbPath);
                }
            }

            // اطمینان از وجود پوشه اصلی
            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

            // 3. آماده‌سازی نام فایل نهایی
            string finalFileName = Path.GetFileNameWithoutExtension(fileName) + ".webp";
            string finalFullPath = Path.Combine(targetDir, finalFileName);

            // 4. پردازش تصویر با ImageSharp
            using (var inputStream = image.OpenReadStream())
            using (var img = Image.Load(inputStream))
            {
                // ذخیره تصویر اصلی (بدون تغییر سایز)
                img.Save(finalFullPath, new WebpEncoder
                {
                    Quality = 80,
                    Method = WebpEncodingMethod.BestQuality
                });

                // 5. تولید Thumbnail (اگر مشخص شده باشد)
                if (!string.IsNullOrEmpty(thumbPath) && width.HasValue && height.HasValue)
                {
                    string thumbDir = Path.Combine(root, thumbPath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                    if (!Directory.Exists(thumbDir)) Directory.CreateDirectory(thumbDir);

                    string thumbFullPath = Path.Combine(thumbDir, finalFileName);

                    // نکته مهم: ایجاد یک کپی از تصویر اصلی برای تغییر سایز تا تصویر اصلی خراب نشود
                    using (var thumbImg = img.Clone(x => x.Resize(width.Value, height.Value)))
                    {
                        thumbImg.Save(thumbFullPath, new WebpEncoder
                        {
                            Quality = 75 // کیفیت تامب‌نیل را کمی کمتر می‌کنیم تا حجم بسیار کم شود
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // در محیط Production، این خطا را لاگ کنید (مثلاً با Serilog)
            throw new Exception($"Error processing image: {ex.Message}", ex);
        }
    }

}

