using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Data;
using Simple_API_Assessment.Data.Repository;
using Simple_API_Assessment.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("simpleAPI");
builder.Services.AddSingleton<IAplicantRepository, ApplicantRepository>(provider =>
{
    return new ApplicantRepository(connectionString);
});
builder.Services.AddDbContext<DataContext>(option => option.UseNpgsql(connectionString));

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
