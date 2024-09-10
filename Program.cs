using APIMANAGEMENT.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TransactionContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("TransactionConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TransactionConnection"))));

builder.Services.
AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();  // Add this line to register the controllers 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.MapControllers(); // Add this line to map the controllers
app.Run();


