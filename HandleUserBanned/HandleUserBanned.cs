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
        CPH.TryGetArg("user", out string user);
        CPH.TryGetArg("userName", out string userName);
        CPH.TryGetArg("createdByUsername", out string createdByUsername);
        CPH.TryGetArg("reason", out string reason);

        string reasonFormatted = !string.IsNullOrEmpty(reason) ? $" Reason: {reason}" : "";
        string banMessage = $"@{user} got banned BOP{reasonFormatted}";

        TwitchUserInfo sbBotInfo = CPH.TwitchGetBot();

        if (userName != sbBotInfo.UserLogin)
        {
            CPH.TryGetArg("broadcastUserName", out string broadcastUserName);

            string banAction = $"banned @{user} BOP{reasonFormatted}";

            switch (createdByUsername)
            {
                case var username when username == sbBotInfo.UserLogin:
                    CPH.SendAction(banAction);

                    break;

                case var username when username == broadcastUserName:
                    CPH.SendAction(banAction, false);

                    break;

                case "sery_bot":
                    CPH.TryGetArg("createdByDisplayName", out string createdByDisplayName);

                    CPH.SendMessage($"@{createdByDisplayName} banned @{user} BOP{reasonFormatted}");

                    CPH.Wait(1000);

                    CPH.SendMessage("good bot");

                    break;

                default:
                    CPH.SendMessage(banMessage);

                    break;
            }

            return true;
        }

        CPH.SendMessage(banMessage, false);

        CPH.Wait(1000);

        CPH.TwitchUnbanUser(userName, false);

        CPH.SendAction($"unbanned @{user} Reason: Wrongfully banned", false);

        CPH.Wait(1000);

        CPH.TwitchAddModerator(userName);

        CPH.SendAction($"re-added @{user} as moderator", false);

        if (createdByUsername == "sery_bot")
        {
            CPH.Wait(1000);

            CPH.SendMessage("bad bot");
        }

        return true;
    }
}
