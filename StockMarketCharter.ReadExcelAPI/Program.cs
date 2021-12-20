using StockMarketCharter.ReadExcelAPI.Services;
using StockMarketCharter.ReadExcelAPI.Repositories;
using StockMarketCharter.ReadExcelAPI.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Adding Cors
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin() //allow any client address
      .AllowAnyMethod() //any http method like get,put,delete,post  
      .AllowAnyHeader();//allow any header like response and request
    });
});

var connectionString = builder.Configuration.GetConnectionString("StockMarketCharterDB");//Getting connection string from appsettings.json
builder.Services.AddDbContext<StockMarketCharterDBContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IStockPriceService, StockPriceService>();
builder.Services.AddScoped<IStockPriceRepository, StockPriceRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
