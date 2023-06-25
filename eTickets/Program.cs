using eTickets.Data;
using eTickets.Models.Repositories;
using eTickets.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Services=builder.Services;
Services.AddControllersWithViews();
Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.
    Configuration.GetConnectionString("DefaultConnectionStrings")));

//Services.AddScoped<IActorService,ActorService>();
Services.AddScoped<IMovieServices, MovieServices>();
Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.Seed(app);
 
app.Run();
