using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace DiscordDemoBot.SlashCommands;

[SlashCommandGroup("basic", "Perform basic tasks")]
public class BasicCommands(ILogger<BasicCommands> logger) : ApplicationCommandModule
{
    [SlashCommand("ping", "Pings the bot")]
    public async Task Test(InteractionContext context)  
    {
        logger.Log(LogLevel.Debug, "Responding to ping");
        await context.CreateResponseAsync(InteractionResponseType.Pong, new()
        {
            Content = "Pong"
        });
    }
}
