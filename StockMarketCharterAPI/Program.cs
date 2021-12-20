//Liberaries used for connecting with database
using Microsoft.EntityFrameworkCore;
using StockMarketCharter.AuthAPI.DBContext;

using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StockMarketCharter.AuthAPI.Entities;
using StockMarketCharter.AuthAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using StockMarketCharter.AuthAPI.Repositories;
using StockMarketCharter.AuthAPI.Services;
using Microsoft.AspNetCore.Identity;

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

//using AddDbContext for contecting to the database
var connectionString = builder.Configuration.GetConnectionString("StockMarketCharterDB");//Getting connection string from appsettings.json
builder.Services.AddDbContext<StockMarketCharterDBContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddMvcCore();


//=============
/*builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<StockMarketCharterDBContext>()
                .AddDefaultTokenProviders();*/



//=============
/*builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.SignIn.RequireConfirmedEmail = true;
});*/

/*services.AddMvc(options =>
{
    options.EnableEndpointRouting = true;
    options.Filters.Add<ValidationFilter>();
})
                    .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>())
                    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);*/



builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
    options.User.RequireUniqueEmail=true;
})
    .AddEntityFrameworkStores<StockMarketCharterDBContext>()
    .AddDefaultTokenProviders();

//=============

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
/*builder.Services.AddScoped<UserManager<I>();*/

//Token
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
x.RequireHttpsMetadata = false;
x.SaveToken = true;
x.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false
};
});

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
app.UseAuthentication();//For Authentication purpose
app.MapControllers();

app.Run();
