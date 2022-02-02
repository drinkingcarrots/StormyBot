using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StormyBot;
using StormyBot.Commands;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace StormyBot
{
    class Bot
    {
        public DiscordClient Client { get; private set; }
        public InteractivityExtension interactivity { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public VoiceNextExtension Voice { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
                //UseInternalLogHandler = true
            };

            Client = new DiscordClient(config);

            Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(5)
            });

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
            };

            Client.VoiceStateUpdated += async (s, e) =>
            {
                
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<ClassCommands>();
            Commands.RegisterCommands<FunCommands>();
            Commands.RegisterCommands<CheckCommands>();
            Commands.RegisterCommands<MathCommands>();
            Commands.RegisterCommands<PointsCommands>();
            Commands.RegisterCommands<MusicCommands>();

            this.Voice = this.Client.UseVoiceNext();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }
    }
}
