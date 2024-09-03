using System;
using Streamer.bot.Plugin.Interface; // Remove in Streamer.bot
using Streamer.bot.Plugin.Interface.Enums; // Remove in Streamer.bot
using Streamer.bot.Plugin.Interface.Model; // Remove in Streamer.bot

/*
    Use this template for Streamer.bot C# code -> copy all code here and paste in Streamer.bot but remove
    marked 'using' Streamer.bot... and remove ": CPHInlineBase" out of "public class CPHInline : CPHInlineBase"
*/

public class CPHInline : CPHInlineBase // Remove ": CPHInlineBase" in Streamer.bot
{
    public bool Execute()
    {
        CPH.TryGetArg("userName", out string userName);

        TwitchUserInfo sbBotInfo = CPH.TwitchGetBot();

        if (userName != sbBotInfo.UserLogin)
        {
            return true;
        }

        CPH.TryGetArg("user", out string user);
        CPH.TryGetArg("reason", out string reason);

        CPH.SendAction(
            $"@{user} got timed out 🤫{(!string.IsNullOrEmpty(reason) ? $" Reason: {reason}" : "")}",
            false
        );

        CPH.Wait(1000);

        CPH.TwitchUnbanUser(userName, false); // There's no dedicated UnTimeout C# method but this works

        CPH.SendAction($"removed timeout on @{user} Reason: Wrongfully timed out", false);

        CPH.Wait(1000);

        CPH.TwitchAddModerator(userName);

        CPH.SendAction($"re-added @{user} as moderator", false);

        CPH.TryGetArg("createdByUsername", out string createdByUsername);

        if (createdByUsername == "sery_bot")
        {
            CPH.Wait(1000);

            CPH.SendMessage("bad bot");
        }

        return true;
    }
}
