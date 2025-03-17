using HealthcareAPI.DataAccess.Abstracts;
using HealthcareAPI.DataAccess.Concretes;
using HealthcareAPI.DataAccess.Contexts;
using HealthcareAPI.Models;
using HealthcareAPI.Services;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);


//  MSSQL Baðlantýsýný Ayarla
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  MongoDB Baðlantýsýný Doðru Tanýmla
builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var mongoClient = new MongoClient(builder.Configuration.GetConnectionString("MongoDB"));
    return mongoClient.GetDatabase("HealthcareDB");
});
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// MongoRepository'yi sadece Hospital için kaydet
builder.Services.AddScoped<IMongoRepository<Hospital>, MongoRepository>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<DoctorService>();





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
