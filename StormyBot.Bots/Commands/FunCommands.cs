using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity.EventHandling;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StormyBot.Bots.Commands
{
    class FunCommands : BaseCommandModule
    {
        GameStuff gameStuff = new GameStuff();

        [Command("rock")]
        [Description("plays rock in the game of rock paper scissors")]
        public async Task Rock(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(gameStuff.RockPaper(0)).ConfigureAwait(false);
        }
        [Command("paper")]
        [Description("plays paper in the game of rock paper scissors")]
        public async Task Paper(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(gameStuff.RockPaper(1)).ConfigureAwait(false);
        }
        [Command("scissors")]
        [Description("plays scissors in the game of rock paper scissors")]
        public async Task Scissor(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(gameStuff.RockPaper(2)).ConfigureAwait(false);
        }
        [Command("coinflip")]
        [Description("flips a coin")]
        public async Task CoinFlip(CommandContext ctx)
        {
            var rnd = new Random();
            int result = rnd.Next(0, 2);

            if (result == 0)
            {
                await ctx.Channel.SendMessageAsync("its heads").ConfigureAwait(false);
            }
            else if (result == 1)
            {
                await ctx.Channel.SendMessageAsync("its tails").ConfigureAwait(false);
            }
        }
        [Command("random")]
        [Description("gives a random digit between 0 and 100")]
        public async Task Random100(CommandContext ctx)
        {
            var rnd = new Random();
            await ctx.Channel.SendMessageAsync("you got " + rnd.Next(0, 101) + " out of 100").ConfigureAwait(false);
        }
        [Command("amogus")]
        [Aliases("amongus")]
        [Description("amogus")]
        public async Task Amogus(CommandContext ctx)
        {
            String[] amogus = new string[] 
          { "https://cdn.discordapp.com/attachments/775541210189135912/905253663088443402/Screenshot_2021-10-08_9.34.05_PM.png",
            "https://tenor.com/view/rainbow-drip-among-drip-drip-epic-rainbow-gif-20851337",
            "https://giphy.com/gifs/cooking-stopmotion-unusual-I8VnyDUEtgDDq2jNlw"};
            Random rnd = new Random();
            await ctx.Channel.SendMessageAsync(amogus[rnd.Next(0, amogus.Length)]).ConfigureAwait(false);
        }

    }
}
