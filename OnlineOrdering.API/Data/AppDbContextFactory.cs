using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OnlineOrdering.API.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();

        // 尝试多种路径查找 appsettings.json
        var candidates = new[]
        {
            basePath,
            Path.Combine(basePath, "OnlineOrdering.API"),
            Path.GetDirectoryName(typeof(AppDbContextFactory).Assembly.Location) ?? basePath,
        };

        string? settingsPath = null;
        foreach (var candidate in candidates)
        {
            if (File.Exists(Path.Combine(candidate, "appsettings.json")))
            {
                settingsPath = candidate;
                break;
            }
        }

        if (settingsPath == null)
        {
            throw new FileNotFoundException(
                $"找不到 appsettings.json。已搜索以下路径：{string.Join(", ", candidates)}");
        }

        var configuration = new ConfigurationBuilder()
            .SetBasePath(settingsPath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("appsettings.json 中未找到 DefaultConnection 连接字符串。");
        }

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 31)));

        return new AppDbContext(optionsBuilder.Options);
    }
}
