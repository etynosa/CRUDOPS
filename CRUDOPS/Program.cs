using CRUDOPS.Infastructure.Database;
using CRUDOPS.Infastructure.Database.Repositories;
using CRUDOPS.Infastructure.Services;
using CRUDOPS.Interfaces.Repositories;
using CRUDOPS.Interfaces.Services;
using CRUDOPS.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var logger = new LoggerConfiguration()
       .ReadFrom.Configuration(builder.Configuration)
       .Enrich.FromLogContext()
       .WriteTo.Console(new RenderedCompactJsonFormatter())
       .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Logging.AddConsole();

builder.Services.AddDbContext<CrudOpsDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DatabaseConnectionString"));
});

string connectionString = "Data Source=crudops.db";
builder.Services.AddTransient<DataSeeder>(provider => new DataSeeder(connectionString));
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CrudOpsDbContext>();

    // Ensure the database is created and migrated
    dbContext.Database.EnsureCreated();
    dbContext.Database.Migrate();

    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    dataSeeder.SeedData();
}

builder.Services.AddTransient<IRandomUserApiClientService, RandomUserApiClientService>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IStudentCoursesRepository, StudentCoursesRepository>();

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

app.Run();
