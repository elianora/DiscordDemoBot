using DiscordDemoBot;
using DiscordDemoBot.SlashCommands;
using DSharpPlus;
using DSharpPlus.SlashCommands;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton(serviceProvider => 
{
    var discordConfig = new DiscordConfiguration
    {
        Token = builder.Configuration["DiscordBot:Token"],
        TokenType = TokenType.Bot,
        Intents = DiscordIntents.AllUnprivileged
    };

    var discordClient = new DiscordClient(discordConfig);
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