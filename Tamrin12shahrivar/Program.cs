using Microsoft.EntityFrameworkCore;
using Tamrin12shahrivar.Data;
using Tamrin12shahrivar.Mapping;
using Tamrin12shahrivar.Repositories.Interface;
using Tamrin12shahrivar.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GemDbContext>(options =>
{
    options.UseSqlServer("Data Source=EHSAN;Initial Catalog=GemRemove;Integrated Security=True;Trust Server Certificate=True");
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(Builder =>
    {
        Builder.AllowAnyHeader();
        Builder.AllowAnyMethod();
        Builder.AllowAnyOrigin();
    });
});
builder.Services.AddScoped<IGemRepository,SQLGemRepository>();
builder.Services.AddAutoMapper(typeof(GemDto));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.UseRouting();
app.MapControllers();

app.Run();
