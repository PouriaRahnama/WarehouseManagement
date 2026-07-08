namespace WarehouseManagement.Application.Common
{
    public static class ApplicationStartup
    {
        public static void ApplicationConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DI ( Registeration Services )
            services.AddHttpContextAccessor();
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddAutoMapper(cfg => { },
                  Assembly.GetExecutingAssembly()
              );

            services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IStockBalanceService, StockBalanceService>();
            services.AddScoped<IStockDocumentService, StockDocumentService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<JwtTokenUtility>();
            #endregion

            #region Idp Registration
            var jwtSettings = configuration.GetSection("JwtSettings");

            //// Add JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(jwtSettings["Key"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = OkApiResult<string>.Fail(null,"توکن ارسال شده معتبر نمی باشد.");
                        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(result));
                    },
                    OnForbidden = async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        context.Response.ContentType = "application/json";

                        var result = OkApiResult<string>.Fail(null,"عدم مجوز دسترسی");
                        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(result));
                    }
                };
            });

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                options.AddPolicy(Policies.Admin, policy =>
                    policy.RequireRole(nameof(UserRole.Admin)));

                options.AddPolicy(Policies.Operator, policy =>
                    policy.RequireRole(nameof(UserRole.Operator),
                              nameof(UserRole.Admin)));

                options.AddPolicy(Policies.Viewer, policy =>
                    policy.RequireRole(
                            nameof(UserRole.Admin),
                            nameof(UserRole.Operator),
                            nameof(UserRole.Viewer)));

            });
            #endregion
        }
    }
}