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
            client.Logger.Log(LogLevel.Debug, $"Button with ID {args.Id} pressed in channel {args.Channel.Name}");
            var buttonText = args.Id switch
            {
                ButtonId.Primary => "primary",
                ButtonId.Secondary => "secondary",
                ButtonId.Success => "success",
                ButtonId.Danger => "danger",
                var buttonId => throw new ArgumentException($"Unknown button type {buttonId}!")
            };

            var messageBuilder = new DiscordInteractionResponseBuilder().WithContent($"The {buttonText} button was pressed!");
            await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, messageBuilder);
        }
        else if (args.Id == DropdownId.TestDropdown)
        {
            var selectedValue = args.Interaction.Data.Values.FirstOrDefault();
            client.Logger.Log(LogLevel.Debug, $"Dropdown with ID {args.Id} had the {selectedValue} option selected in channel {args.Channel.Name}");
            
            var messageBuilder = new DiscordInteractionResponseBuilder().WithContent($"Option {selectedValue} was selected");
            await args.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, messageBuilder);
        }
        else
        {
            client.Logger.Log(LogLevel.Debug, $"Unknown component with ID {args.Id} had an interaction in channel {args.Channel.Name}");
            throw new ArgumentException($"Unknown component interaction type {args.Id}");
        }
    }
}

