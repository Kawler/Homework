using Project.Models;
using Project.Repositories;
using Project.Services;

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

var app = builder.Build();
app.MapControllers();

app.Run();