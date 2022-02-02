using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity.EventHandling;
using DSharpPlus.Interactivity;
using DSharpPlus.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace StormyBot.Commands
{
    class ClassCommands : BaseCommandModule
    {
        Sorting sorting = new Sorting();

        string[,] classInfo = new string[,]
          { {"1", "2", "3", "4", "5", "6", "error, your level was typed wrong."},
            {"7", "8", "9", "10", "11", "12", "error, your level was typed wrong."},
            {"13", "14", "15", "16", "17", "18", "error, your level was typed wrong."} };

        Hashtable schedule = new Hashtable();

        [Command("setclass")]
        [Description("a command for seniors to set their classes")]
        [RequireRoles(RoleCheckMode.Any, "Admin", "Staff", "Instructors", "Seniors", "testrole")]
        public async Task SetClass(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            await ctx.Channel.SendMessageAsync("are you teaching level 1, 2a ,2b ,3 ,4 or 5").ConfigureAwait(false);

            var message = await interactivity.WaitForMessageAsync(x => x.Author == ctx.Member).ConfigureAwait(false);

            int level = sorting.levelSorter(message.Result.Content);

            await ctx.Channel.SendMessageAsync("cool, i got your level as " + message.Result.Content + ". now is your class in period 1, 2, or 3?").ConfigureAwait(false);

            message = await interactivity.WaitForMessageAsync(x => x.Author == ctx.Member).ConfigureAwait(false);

            int period = sorting.PeriodSorter(message.Result.Content);
            try
            {
                await ctx.Channel.SendMessageAsync("you are about to replace what ever this says -->" + classInfo[period, level]).ConfigureAwait(false);
            }
            catch
            {
                await ctx.Channel.SendMessageAsync("error, try again. you probably messed up the period.").ConfigureAwait(false);
            }

            await ctx.Channel.SendMessageAsync("are you sure? yes/no").ConfigureAwait(false);
            message = await interactivity.WaitForMessageAsync(x => x.Author == ctx.Member).ConfigureAwait(false);

            bool yesNo = sorting.YesNoSorter(message.Result.Content);

            if (yesNo == true)
            {
                await ctx.Channel.SendMessageAsync("ok, now type out the message you want your cadets to see when they check their classes. make sure to include your Name, classroom, and anything else you want them to see.").ConfigureAwait(false);
                var finalMessage = await interactivity.WaitForMessageAsync(x => x.Author == ctx.Member).ConfigureAwait(false);

                classInfo[period, level] = (finalMessage.Result.Content);
                await ctx.Channel.SendMessageAsync("everything looks good on my end. use ?class to check if it worked.").ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("canceled.").ConfigureAwait(false);
            }
        }

        [Command("class")]
        [Description("a command to automatically check a specific class for the day")]
        public async Task ClassAuto(CommandContext ctx)
        {
            DiscordRole[] allLevels = new DiscordRole[] 
            { ctx.Guild.GetRole(701157383128481902),
              ctx.Guild.GetRole(701158045614473390),
              ctx.Guild.GetRole(768591984633184256),
              ctx.Guild.GetRole(701158022063325314),
              ctx.Guild.GetRole(701158049305460746),
              ctx.Guild.GetRole(701158052375691635)};
            for (int level = 0; level < allLevels.Length; level++)
            {
                if (ctx.Member.Roles.Contains(allLevels[level]))
                {
                    await ctx.Channel.SendMessageAsync("hello " + ctx.Member.Nickname + ". your class information in the order of period 1, 2, and 3 are: \n \n" + classInfo[0, level] + "\n \n" + classInfo[1, level] + "\n \n" + classInfo[2, level]).ConfigureAwait(false);
                }
            }
        }
        [Command("classmanual")]
        [Aliases("classmanuel")]
        [Description("a command to check a specific class")]
        public async Task ClassManual(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            await ctx.Channel.SendMessageAsync("whould you like to check level 1, 2a, 2b, 3, 4, or 5").ConfigureAwait(false);

            var message = await interactivity.WaitForMessageAsync(x => x.Author == ctx.Member).ConfigureAwait(false);

            int level = sorting.levelSorter(message.Result.Content);

            await ctx.Channel.SendMessageAsync("now would you like to check period 1, 2 ,3, or all").ConfigureAwait(false);

            message = await interactivity.WaitForMessageAsync(x => x.Author == ctx.Member).ConfigureAwait(false);

            if (message.Result.Content.Contains("a") == true)
            {
                for(int i = 0; i <= 2; i++)
                {
                    await ctx.Channel.SendMessageAsync(classInfo[i, level]).ConfigureAwait(false);
                }
            }
            else
            {
                int period = sorting.PeriodSorter(message.Result.Content);

                await ctx.Channel.SendMessageAsync(classInfo[period, level]).ConfigureAwait(false);
            }
        }
    }
}
