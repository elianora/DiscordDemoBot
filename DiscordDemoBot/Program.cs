using DiscordDemoBot;
using DiscordDemoBot.EventHandlers;
using DiscordDemoBot.SlashCommands;
using DSharpPlus;
using DSharpPlus.SlashCommands;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton(serviceProvider => 
{
    var discordConfig = new DiscordConfiguration
    {
        Token = builder.Configuration["DiscordBotToken"],
        TokenType = TokenType.Bot,
        Intents = DiscordIntents.AllUnprivileged,
        MinimumLogLevel = LogLevel.Information,
        LogTimestampFormat = "MMM dd yyyy - hh:mm:ss tt"
    };

    var discordClient = new DiscordClient(discordConfig);
    discordClient.ComponentInteractionCreated += BasicHandlers.OnComponentInteraction;

    var slashCommandsConfig = new SlashCommandsConfiguration
    {
        Services = serviceProvider
    };

    var slashCommands = discordClient.UseSlashCommands(slashCommandsConfig);
    slashCommands.RegisterCommands<BasicCommands>();

    return discordClient;
});

var host = builder.Build();

host.Run();
