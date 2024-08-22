using IWPPage.Services.Implimentation;
using IWPPage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using OTA_Portal_Service;
using OTA_Portal_Service.DataBaseContext;
using OTA_Portal_Service.Services.Implimentations;
using OTA_Portal_Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IRepositoryService, RepositoryService>();
builder.Services.AddScoped<IHelperSrevice, HelperService>();
builder.Services.AddScoped<ITraineeService, TraineeService>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddDbContext<HomeDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("OTADatabase")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// to add a file like image
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
    RequestPath = new PathString("/wwwroot")
});
app.UseHttpsRedirection();
app.UseCors(builder => {
    builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
    });

app.UseAuthorization();

app.MapControllers();

app.Run();
