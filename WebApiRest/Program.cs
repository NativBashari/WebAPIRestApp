using Contract.Contracts;
using Entities;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<APIDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMvc();
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();