using Microsoft.EntityFrameworkCore;
using PayrollService.Data;
using PayrollService.Repositories.Interface;
using PayrollService.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For Entity Framework  
builder.Services.AddDbContext<EmployeeDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployee, SQLEmployee>();
  

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");



var app = builder.Build();

var supportedCultures = new[] { "en-US", "en", "id", };
var localizationOptions=
    new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseMiddleware<GlobalErrorHandlingMiddleware>();
//app.UseMiddleware<GlobalExceptionMiddleware>(); 

app.MapControllers();

app.Run();
