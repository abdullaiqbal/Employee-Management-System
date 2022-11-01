using EmployeeManagmentWeb.DataContext;
using EmployeeManagmentWeb.Models;
using EmployeeManagmentWeb.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
       
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DeleteRolePolicy",
        policy => policy.RequireClaim("Delete Role","true"));
    options.AddPolicy("AdminRolePolicy",
        policy => policy.RequireRole("Admin"));
    options.AddPolicy("SuperAdminPolicy",
        policy => policy.RequireRole("Super Admin"));
    //options.AddPolicy("AdminSuperAdminPolicy",
    //    policy => policy.RequireRole("Super Admin","Admin").RequireClaim("Edit User"));
    //options.AddPolicy("AdminSuperAdminPolicy",
    //    policy => policy.RequireAssertion(context => context.User.IsInRole("Admin") &&
    //                                                 context.User.HasClaim(claim => claim.Type == "Edit User" && claim.Value == "true") 
    //                                              || context.User.IsInRole("Super Admin")));


    options.AddPolicy("AdminSuperAdminPolicy",
        policy => policy.RequireAssertion(context => context.User.IsInRole("Admin")
                                                  || context.User.IsInRole("Super Admin")));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EditUserPolicy", policy =>
        policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler,
    CanEditOnlyOtherAdminRolesAndClaimsHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();
builder.Services.AddAuthentication()
    .AddGoogle(options =>
     {
         options.ClientId = "258800303662-adgu33g8vfeg0rfmmpt3vrk4cbl6hnbr.apps.googleusercontent.com";
         options.ClientSecret = "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";
     })
     .AddFacebook(options =>
     {
         options.AppId = "878319143539201";
         options.AppSecret = "ac829bbe82c8b4334596441bc6444228";
     });
builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
        o.TokenLifespan = TimeSpan.FromHours(5));
//builder.Services.AddMvc(o => o.EnableEndpointRouting = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Home}/{action=Index}/{id?}");

app.Run();
