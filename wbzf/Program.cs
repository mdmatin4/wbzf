using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Data.Initializer;
using wbzf.DataAccess.Repository;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequireNonAlphanumeric = false;
    option.User.RequireUniqueEmail = false;
}).AddErrorDescriber<AppErrorDescriber>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


// Adding Custom Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "JWT_OR_COOKIE";
    options.DefaultChallengeScheme = "JWT_OR_COOKIE";
})
    .AddCookie( options =>
    {
        options.LoginPath = "/Identity/Account/Login";
        options.LogoutPath = "/Identity/Account/Logout";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    })

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:Audience"],
        ValidIssuer = configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
}).AddPolicyScheme("JWT_OR_COOKIE", "JWT_OR_COOKIE", options =>
{
    // runs on each request
    options.ForwardDefaultSelector = context =>
    {
        // filter by url all the api request will be prefixed by api
        
        if (context.Request.Path.Value.Contains("/api/", StringComparison.OrdinalIgnoreCase))
            return JwtBearerDefaults.AuthenticationScheme;

        // otherwise always check for cookie auth
        return CookieAuthenticationDefaults.AuthenticationScheme;
    };
}); ;


builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors();


builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    // enables immediate logout, after updating the user's stat.
    options.ValidationInterval = TimeSpan.FromSeconds(120);
});

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"\data-protection\"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseCors(builder =>
{
    builder.WithOrigins(configuration["Company:api_url"]) // Update with the domain of your Angular app
           .AllowAnyHeader()
           .AllowAnyMethod();
});


SeedDatabase();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}