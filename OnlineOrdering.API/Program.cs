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
builder.Services.AddScoped<IDeliveryZoneService, DeliveryZoneService>();
builder.Services.AddScoped<IDiningTableService, DiningTableService>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddHttpClient<IAiService, AiService>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", p =>
    {
        p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    await DbSeeder.SeedAsync(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseStaticFiles();
app.MapControllers();
app.Run();
