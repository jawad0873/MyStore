using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyStore.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyStoreDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MyStoreDbContextConnection' not found.");

builder.Services.AddDbContext<MyStoreDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MyStoreUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MyStoreDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] {"Manager","Admin" ,"Member"};

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }

    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<MyStoreUser>>();

    var email = "jawaddeveloper@gmail.com";
    var pass = "123456";
    // string role = "Admin";
    var adm = new List<string> { "Admin" };
    // if (await userManager.FindByEmailAsync(email) !=null)
    //{

    var user = await userManager.FindByEmailAsync(email);

      //  var user = new MyStoreUser();
        //user.Email = email;
        //user.UserName = email;
        //user.FirstName = "Adil";
        //user.LastName = "Khan";

         //userManager.CreateAsync(user, pass);
        await userManager.AddToRolesAsync(user, adm);

  //  }


}

app.Run();
