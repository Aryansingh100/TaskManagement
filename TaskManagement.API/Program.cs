using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Interfaces;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(); // Required for JSON Patch
// Configure SQLite Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register Repository
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
app.MapOpenApi();
}
app.UseAuthorization();
app.MapControllers();
app.Run();