using Microsoft.EntityFrameworkCore;
using PackardJStudentDatabase.Data;
using PackardJStudentDatabase.Models;
using PackardJStudentDatabase.Services.Students;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DatabaseConnection"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(option => {
	option.AddPolicy("CORSPolicy",
	builder => {
		builder.AllowAnyHeader()
		.AllowAnyMethod()
		.AllowAnyOrigin();
	}
	);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CORSPolicy");

app.MapControllers();

app.Run();
