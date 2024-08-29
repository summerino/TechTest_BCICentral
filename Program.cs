using Microsoft.EntityFrameworkCore;
using TechTest_BCICentral.Data;
using TechTest_BCICentral.Domain.Interfaces;
using TechTest_BCICentral.Domain.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TechTest_BCICentralContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TechTest_BCICentralContext") ?? throw new InvalidOperationException("Connection string 'TechTest_BCICentralContext' not found.")));

// Add services to the container.
builder.Services.AddScoped<IConstructionProjectService, ConstructionProjectService>();
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
