using ApplicationRocket.Commands;
using ApplicationRocket.Queries;
using Microsoft.EntityFrameworkCore;
using RocketAPI.Utilities;
using RocketData.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<RocketContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.RegisterBusinessServices();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(),
    typeof(CreateRocketCommand).Assembly,
    typeof(UpdateRocketCommand).Assembly,
    typeof(DeleteRocketCommand).Assembly,
    typeof(GetAllRocketsQuery).Assembly,
    typeof(GetRocketByIdQuery).Assembly
    ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
