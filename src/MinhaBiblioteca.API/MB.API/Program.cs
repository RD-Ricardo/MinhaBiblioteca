using MB.Core.Communication.Mediator;
using MB.Data;
using MB.Data.Repositories;
using MB.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
var connectionSring = "server=localhost;database=dbmb;uid=root;pwd=root;";
builder.Services.AddDbContext<MinhaBibliotecaDbContext>(x => x.UseMySql(connectionSring, ServerVersion.AutoDetect(connectionSring)));
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
//builder.Services.AddScoped<IUsuarioRepository, Usua>();

builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("MB.Application"));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
