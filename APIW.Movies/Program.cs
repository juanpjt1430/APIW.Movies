using APIW.Movies.DAL;
using APIW.Movies.MoviesMapper;
using APIW.Movies.Repository;
using APIW.Movies.Repository.IRepository;
using APIW.Movies.Services;
using APIW.Movies.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<Mappers>());

// Dependency Injection for Services
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Dependency Injection for Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

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