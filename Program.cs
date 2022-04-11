using Microsoft.EntityFrameworkCore;
using Ticket_System.Filters;
using Ticket_System.Services.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ILoginManageService, LoginManageService>();
builder.Services.AddTransient<ITicketsManageService, TicketsManageService>();
builder.Services.AddTransient<IUserManageService, UserManageService>();
builder.Services.AddScoped<IAccessManageService, AccessManageService >();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(CustomAuthorizationFilter));
});
builder.Services.AddDbContext<TicketDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TicketDB"));
});


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ticket}/{action=Index}/{id?}");

app.Run();
