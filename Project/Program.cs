using Project.Models;
using Project.Repositories;
using Project.Services;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ISubjectsRepository>(s =>
    new SubjectsRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ISubjectsService, SubjectsService>();

builder.Services.AddScoped<ITeacherRepository>(s =>
    new TeacherRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddScoped<IScheduleRepository>(s =>
    new ScheduleRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IScheduleService, ScheduleService>();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}
));

var app = builder.Build();
app.UseCors("corspolicy");
app.MapControllers();
app.Run();
