using DSharpPlus;

namespace DiscordDemoBot;

public class Worker(DiscordClient discordClient) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        discordClient.Logger.Log(LogLevel.Information, "Starting DiscordDemoBot...");
        await discordClient.ConnectAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        discordClient.Logger.Log(LogLevel.Information, "Stopping DiscordDemoBot...");
        await discordClient.DisconnectAsync();
        discordClient.Dispose();
    }
}
