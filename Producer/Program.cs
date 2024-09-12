using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Producer;
using Producer.Services;
using Services.Context;

public class Program {
    public static void Main(string[] args) {
        var host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        var app = scope.ServiceProvider.GetRequiredService<App>();
        app.Start();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) => {
                services.AddSingleton<RabbitContext>();
                services.AddScoped<App>();
                services.AddScoped<RelatorioService>();
                services.AddScoped<NotificationService>();
            });
}