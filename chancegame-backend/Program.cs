using chancegame_backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ChanceGameDbContext>(options =>
  options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = ChanceGameDB; Trusted_Connection = True; "));

builder.Services.AddCors(options => {
    options.AddPolicy(MyAllowSpecificOrigins,
                          builder => {
                              builder.WithOrigins("https://localhost:44322/api/CardModels").SetIsOriginAllowedToAllowWildcardSubdomains()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.Run();