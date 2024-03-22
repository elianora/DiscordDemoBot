using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DiscordDemoBot.Models;

namespace DiscordDemoBot.EventHandlers;

public class BasicHandlers
{
    public static async Task OnButtonPressed(DiscordClient _, ComponentInteractionCreateEventArgs args)
    {
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
}

