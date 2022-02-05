using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using ProjectDataCore.Data.Database;
using ProjectDataCore.Data.Services.Nav;
using ProjectDataCore.Data.Services.User;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(Path.Join("Config", "website_config.json"));

// Add services to the container.
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("database"))
#if DEBUG
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
#endif
    // Warnings for loading multiple collections without splitting the query.
    // We want this behaviour for accurate data loading (and our lists are not
    // of any large size for the roster) so we are ignoring these.
    .ConfigureWarnings(w =>
        w.Ignore(RelationalEventId.MultipleCollectionIncludeWarning))
    , ServiceLifetime.Singleton);

builder.Services.AddScoped(p
    => p.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

// END DATABASE SETUP

builder.Services.AddIdentity<DataCoreUser, DataCoreRole>()
    .AddDefaultTokenProviders()
    .AddRoleManager<DataCoreRoleManager>()
    .AddSignInManager<DataCoreSignInManager>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// END ACCOUNT SETUP

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

#if DEBUG
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
#endif

// END BLAZOR SETUP

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 2;
    options.Password.RequiredUniqueChars = 0;
});

// END PASSWORD SETUP

builder.Services.AddScoped<IModularRosterService, ModularRosterService>()
    .AddScoped<IPageEditService, PageEditService>()
    .AddScoped<IScopedUserService, ScopedUserService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<INavModuleService, NavModuleService>()
    .AddScoped<IAssignableDataService, AssignableDataService>();

builder.Services.AddSingleton<IRoutingService, RoutingService>()
    .AddSingleton<RoutingService.RoutingServiceSettings>(x =>
    {
        var asm = Assembly.GetAssembly(typeof(ProjectDataCore.Components._Imports));

        if (asm is null)
            throw new Exception("Missing components assembly.");

        return new(asm);
    });

// END SERVICE SETUP

// END DISCORD SETUP

// END ACCOUNT LINK SETUP

// END PERMISSION SETUP

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
var dbFac = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
using var db = dbFac.CreateDbContext();
ApplyDatabaseMigrations(db);

// START VALIDATE ADMIN ACCOUNT

var usrMngr = scope.ServiceProvider.GetRequiredService<UserManager<DataCoreUser>>();
var usr = await usrMngr.FindByNameAsync("Administrator");
if(usr is null)
{
    usr = new()
    {
        UserName = "Administrator"
    };

    await usrMngr.CreateAsync(usr, app.Configuration["Startup:Password"]);
    var usrServ = scope.ServiceProvider.GetRequiredService<IAssignableDataService>();

    usr = await usrMngr.FindByNameAsync("Administrator");
    await usrServ.EnsureAssignableValuesAsync(usr);
}

// END VALIDATE ADMIN ACCOUNT

app.UseForwardedHeaders(new ForwardedHeadersOptions()
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();

static void ApplyDatabaseMigrations(DbContext database)
{
    if (!(database.Database.GetPendingMigrations()).Any())
    {
        return;
    }

    database.Database.Migrate();
    database.SaveChanges();
}