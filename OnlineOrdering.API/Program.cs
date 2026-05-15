using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31))
    )
);

builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();//添加统计服务
builder.Services.AddHttpClient<IAiService, AiService>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", p =>
    {
        p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.MapControllers();
app.Run();
