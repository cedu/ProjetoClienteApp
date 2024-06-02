using ProjetoClienteApp.Api.Extensions;
using ProjetoClienteApp.Api.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(map =>
{
    map.LowercaseUrls = true;
});

builder.Services.AddSwaggerDoc();
builder.Services.AddDependencyInjection();

//Pol�tica de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("DefaultPolicy"); //Pol�tica de CORS

app.MapControllers();

app.Run();

public partial class Program { }

