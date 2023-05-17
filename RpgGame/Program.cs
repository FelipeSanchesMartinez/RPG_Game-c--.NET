using Newtonsoft.Json;
using RpgGame.Data;
using RpgGame.Interfaces;
using RpgGame.Mappers;
using RpgGame.Models;
using RpgGame.Services;
using RpgGame.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<SQLContext>();

builder.Services.AddScoped<IPersonagemService, PersonagemService>();
builder.Services.AddScoped<IPartidaService, PartidaService>();

builder.Services.AddAutoMapper(typeof(ViewModelParaModel));

builder.Services.AddCors(opt => opt.AddPolicy("*", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("*");

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
