using StockMarketCharter.StockAPI.Services;
using StockMarketCharter.StockAPI.Repositories;
using StockMarketCharter.StockAPI.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStockExchangeService, StockExchangeService>();
builder.Services.AddScoped<IStockExchangeRepository, StockExchangeRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();



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
