using DSharpPlus;

namespace DiscordDemoBot;

public class Worker(ILogger<Worker> logger, DiscordClient discordClient) : BackgroundService
{
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.Log(LogLevel.Information, "Starting DiscordDemoBot...");
        }

        await discordClient.ConnectAsync();
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.Log(LogLevel.Information, "Stopping DiscordDemoBot...");
        }

        await discordClient.DisconnectAsync();
        discordClient.Dispose();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
        => Task.CompletedTask;
}
