using AlManalChickens.Domain.Entities.UserTables;
using AlManalChickens.Domain.Model;
using AlManalChickens.Hubs;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Persistence;
using AlManalChickens.Persistence.Seeds;
using AlManalChickens.Services.Middlewares.UserConfigs;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
Hosting.Environment = builder.Environment;

builder.Services.AddController();
builder.Services.AddSingletonServices();
builder.Services.AddDbContextServices(builder.Configuration);
builder.Services.AddDefaultIdentityServices();
builder.Services.AddLocalizationServices();
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddCorsServices();
builder.Services.AddRazorPages();
builder.Services.AddSingletonServices();
builder.Services.AddScopedServices();
builder.Services.AddTransientServices();
builder.Services.AddSession();
builder.Services.AddJwtServices(builder.Configuration);
builder.Services.TimeOutServices(builder.Environment);
builder.Services.AddAutoMapper(typeof(IStartup));
builder.Services.AddSignalR();
builder.Services.AddFluentValidation();
//builder.Services.AddFireBase(); // Uncomment when you start using FCM
builder.Services.AddMVC();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.ScanAllServices();

#region Data Protection

builder.Services.AddDataProtection().SetApplicationName($"my-app-{builder.Environment.EnvironmentName}")
    .SetDefaultKeyLifetime(TimeSpan.FromDays(365))
    .PersistKeysToFileSystem(new DirectoryInfo($@"{builder.Environment.ContentRootPath}\keys"));

#endregion

var app = builder.Build();

// should be after build
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationDbUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
    await ContextSeed.Seed(userManager, roleManager, applicationDbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.ConfigureSwagger();

var options = ConfigureServiceContainer.GetLocalizationOptions();
app.UseRequestLocalization(options);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseUserConfigMiddleware();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // add endpoints to chatHub
    endpoints.MapHub<ChatHub>("/chatHub");

    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();