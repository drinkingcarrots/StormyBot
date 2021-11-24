using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity.EventHandling;
using DSharpPlus.Interactivity;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace StormyBot.Bots.Commands
{
    class MathCommands : BaseCommandModule
    {
        BotMath botMath = new BotMath();
        Sorting sorting = new Sorting();
        [Command("Math")]
        [Description("creates a friendly math compitition")]
        public async Task EasyMath(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var answers = botMath.EasyRandomizer();
            await ctx.Channel.SendMessageAsync(Convert.ToString(answers[0])).ConfigureAwait(false);

            for (int i = 0; i < 15; i++)
            {
                var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

                if ( sorting.MathCheck(message.Result.Content, answers[1]))
                {
                    await ctx.Channel.SendMessageAsync(message.Result.Author.Mention + "wins!").ConfigureAwait(false);
                    break;
                }
            }
        }
        [Command("hardmath")]
        [Description("creates a harder friendly math compitition")]
        public async Task Rock(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var answers = botMath.HardRandomizer();
            await ctx.Channel.SendMessageAsync(Convert.ToString(answers[0])).ConfigureAwait(false);

            for (int i = 0; i < 15; i++)
            {
                var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

                if (sorting.MathCheck(message.Result.Content, answers[1]))
                {
                    await ctx.Channel.SendMessageAsync(message.Result.Author.Mention + "wins!").ConfigureAwait(false);
                    break;
                }
            }
        }

    }
}
