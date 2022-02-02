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

namespace StormyBot.Commands
{
    class PointsCommands : BaseCommandModule
    {
        [Command("checkpoints")]
        [Description("test")]
        public async Task CheckPoints(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("balls").ConfigureAwait(false);
        }
    }
}

