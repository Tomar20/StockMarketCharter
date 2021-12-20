using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddOcelot();
Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, o) =>
{
    o.AddJsonFile("ocelot.json", optional:false, reloadOnChange: true)
    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOcelot();
app.UseAuthorization();

app.MapControllers();

app.Run();
