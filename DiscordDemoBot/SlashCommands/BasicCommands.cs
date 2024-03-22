using DiscordDemoBot.Models;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace DiscordDemoBot.SlashCommands;

public class BasicCommands : ApplicationCommandModule
{
    [SlashCommand("ping", "Pings the bot")]
    public async Task PingAsync(InteractionContext context)  
    {
        context.Client.Logger.Log(LogLevel.Debug, $"Responding to ping from {context.User.Username} in channel {context.Channel.Name}...");
        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new()
        {
            Content = "Pong"
        });
    }

    [SlashCommand("avatar", "Gets the current user's avatar")]
    public async Task GetAvatarAsync(InteractionContext context)
    {
        context.Client.Logger.Log(LogLevel.Debug, $"Getting {context.User.Username}'s avatar in channel {context.Channel.Name}...");
        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new()
        {
            Content = context.User.AvatarUrl,
        });
    }

    [SlashCommand("button-test", "Tests button interactivity")]
    public async Task ButtonTestAsync(InteractionContext context)
    {
        context.Client.Logger.Log(LogLevel.Debug, $"Presenting test buttons for {context.User.Username} in channel {context.Channel.Name}...");
        var buttons = new DiscordButtonComponent[]
        {
            new(ButtonStyle.Primary, ButtonId.Primary, "Primary"),
            new(ButtonStyle.Secondary, ButtonId.Secondary, "Secondary"),
            new(ButtonStyle.Success, ButtonId.Success, "Success"),
            new(ButtonStyle.Danger, ButtonId.Danger, "Danger")
        };

        var messageBuilder = new DiscordInteractionResponseBuilder().WithContent("Please select a button.").AddComponents(buttons);
        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, messageBuilder);
    }

    [SlashCommand("dropdown-test", "Tests dropdown interactivity")]
    public async Task DropdownTestAsync(InteractionContext context)
    {
        context.Client.Logger.Log(LogLevel.Debug, $"Presenting dropdown for {context.User.Username} in channel {context.Channel.Name}...");
        var dropdownOptions = new List<DiscordSelectComponentOption>() 
        {
            new("Option 1", "1", "Select this option for 1"),
            new("Option 2", "2", "Select this option for 2"),
            new("Option 3", "3", "Select this option for 3")
        };

        var dropdown = new DiscordSelectComponent(DropdownId.TestDropdown, "Select an option...", dropdownOptions);
        var messageBuilder = new DiscordInteractionResponseBuilder().AddComponents(dropdown);
        await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, messageBuilder);
    }
}
