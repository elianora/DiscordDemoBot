using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace DiscordDemoBot.SlashCommands;

public class BasicCommands(ILogger<BasicCommands> logger) : ApplicationCommandModule
{
    [SlashCommand("ping", "Pings the bot")]
    public async Task PingAsync(InteractionContext context)  
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

    [SlashCommand("avatar", "Gets the current user's avatar")]
    public async Task GetAvatarAsync(InteractionContext context)
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.Log(LogLevel.Debug, "Getting current user's avatar...");
        }

        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new()
        {
            Content = context.User.AvatarUrl
        });
    }
}
