using AluraFlixAPI.Data;
using AluraFlixAPI.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AluraFlixConnection");
// Add services to the container.



builder.Services.AddControllers().AddNewtonsoftJson
    (opts => opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<AluraFlixContext>
    (
    opts=> opts.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString))
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.
    AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<VideoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
