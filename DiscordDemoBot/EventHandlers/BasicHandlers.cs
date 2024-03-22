using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DiscordDemoBot.Models;

namespace DiscordDemoBot.EventHandlers;

public class BasicHandlers
{
    public static async Task OnComponentInteraction(DiscordClient client, ComponentInteractionCreateEventArgs args)
    {
        if (args.Id.EndsWith("_button"))
        {
            client.Logger.Log(LogLevel.Debug, $"Button with ID {args.Id} pressed in channel {args.Channel.Name}...");
            var buttonText = args.Id switch
            {
                ButtonId.Primary => "primary",
                ButtonId.Secondary => "secondary",
                ButtonId.Success => "success",
                ButtonId.Danger => "danger",
                _ => throw new ArgumentException("Unknown button type!")
            };

            var messageBuilder = new DiscordInteractionResponseBuilder().WithContent($"The {buttonText} button was pressed!");
            await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, messageBuilder);
        }
        else if (args.Id.EndsWith("_dropdown"))
        {
            client.Logger.Log(LogLevel.Debug, $"Dropdown with ID {args.Id} had an option selected in channel {args.Channel.Name}...");
            var messageBuilder = new DiscordInteractionResponseBuilder().WithContent($"Option {args.Interaction.Data.Values[0]} was selected");
            await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, messageBuilder);
        }
    }
}

