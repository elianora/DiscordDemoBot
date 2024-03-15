using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace DiscordDemoBot.SlashCommands;

public class BasicCommands(ILogger<BasicCommands> logger) : ApplicationCommandModule
{
    [SlashCommand("ping", "Pings the bot")]
    public async Task Test(InteractionContext context)  
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.Log(LogLevel.Debug, "Responding to ping...");
        }

        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new()
        {
            Content = "Pong"
        });
    }
}
