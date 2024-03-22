using DSharpPlus;

namespace DiscordDemoBot;

public class Worker(DiscordClient discordClient) : BackgroundService
{
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        discordClient.Logger.Log(LogLevel.Information, "Starting DiscordDemoBot...");
        await discordClient.ConnectAsync();
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        discordClient.Logger.Log(LogLevel.Information, "Stopping DiscordDemoBot...");
        await discordClient.DisconnectAsync();
        discordClient.Dispose();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
        => Task.CompletedTask;
}
