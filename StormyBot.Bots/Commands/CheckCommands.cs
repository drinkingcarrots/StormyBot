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
    class CheckCommands : BaseCommandModule
    {
        Sorting sorting = new Sorting();
        [Command("paradestaff")]
        [Description("checks all the parade staff")]
        public async Task ParadeStaff(CommandContext ctx)
        {
            var members = ctx.Guild.GetAllMembersAsync().Result;

            string paradeStaff = "";

            foreach (var member in members)
            {
                if (member.Roles.Contains(ctx.Guild.GetRole(688224925127147536)))
                {
                    
                    paradeStaff = (paradeStaff + sorting.NickNameFix(member.Nickname, member.Username) + "\n");
                    
                }
            }
            await ctx.Channel.SendMessageAsync("the current parade staff is: \n" + paradeStaff).ConfigureAwait(false);
        }
        [Command("flightstaff")]
        [Description("checks all the flight staff")]
        public async Task FlightStaff(CommandContext ctx)
        {
            var members = ctx.Guild.GetAllMembersAsync().Result;

            DiscordRole[] allStaffRoles = new DiscordRole[]
            { ctx.Guild.GetRole(766496315764375582),
              ctx.Guild.GetRole(766496431867297812),
              ctx.Guild.GetRole(766496605486448661),
              ctx.Guild.GetRole(766496699191132181),
              ctx.Guild.GetRole(766497195129569291),
              ctx.Guild.GetRole(766499425496334357),
              ctx.Guild.GetRole(766497186455224350),
              ctx.Guild.GetRole(766498283023237170),
              ctx.Guild.GetRole(766499257770442763),
              ctx.Guild.GetRole(766498574040563712),
              ctx.Guild.GetRole(766498873744424991),
              ctx.Guild.GetRole(766499810651406366),
              ctx.Guild.GetRole(766494674550521876),
              ctx.Guild.GetRole(766499959951589388),
              ctx.Guild.GetRole(766498765484851231)};

            string paradeStaff = "";

            foreach (var staffRole in allStaffRoles)
            {
                foreach (var member in members)
                {
                    if (member.Roles.Contains(staffRole))
                    {
                        paradeStaff = (paradeStaff + staffRole.Name + ": " + sorting.NickNameFix(member.Nickname, member.Username) + "\n");
                    }
                }
            }
            await ctx.Channel.SendMessageAsync("the current parade staff are: \n" + paradeStaff).ConfigureAwait(false);
        }
        [Command("staff")]
        [Description("checks all the staff")]
        public async Task Staff(CommandContext ctx)
        {
            var members = ctx.Guild.GetAllMembersAsync().Result;

            string paradeStaff = "";

            foreach (var member in members)
            {
                if (member.Roles.Contains(ctx.Guild.GetRole(692542146699460638)))
                {
                    paradeStaff = (paradeStaff + sorting.NickNameFix(member.Nickname, member.Username) + "\n");
                }
            }
            await ctx.Channel.SendMessageAsync("the current staff are: \n" + paradeStaff).ConfigureAwait(false);
        }
    }
}
