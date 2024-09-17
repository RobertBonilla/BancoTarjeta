using BCOAPI.Core;
using BCOAPI.Infraestructure;
using BCOAPI.Core.Interfaces;
using BCOAPI.Core.Services;
using BCOAPI.Infraestructure.Interfaces;
using BCOAPI.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddTransient<ITransactionService, TransactionService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<ICargoRepository, CargoRepository>();
builder.Services.AddTransient<IAbonoRepository, AbonoRepository>();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(MediatREntrypoint).Assembly));
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddHealthChecks();
//Add the service

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

app.MapHealthChecks("Healt");

app.Run();
