using ClientCore.API;
using ClientCore.Business.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlServer<ClientCoreDBContext>(connString);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// or more typically, using IServiceCollection
builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<CreateClientDTO, Client>();
    cfg.CreateMap<Client, GetClientDTO>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClientService, ClientService>();

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
await app.MigrateDbAsyncy();

app.Run();
