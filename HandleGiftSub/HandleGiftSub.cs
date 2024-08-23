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
        CPH.TryGetArg("fromGiftBomb", out bool fromGiftBomb);

        if (fromGiftBomb)
        {
            return true;
        }

        CPH.TryGetArg("anonymous", out bool anonymous);
        CPH.TryGetArg("user", out string user);
        CPH.TryGetArg("tier", out string tier);
        CPH.TryGetArg("cumulativeMonths", out int cumulativeMonths);
        CPH.TryGetArg("monthsGifted", out int monthsGifted);
        CPH.TryGetArg("totalSubsGifted", out int totalSubsGifted);
        CPH.TryGetArg("recipientUser", out string recipientUser);

        string gifter = anonymous ? "Anonymous" : $"@{user}";

        // Gifted subscriptions can never be Prime
        string tierFormatted = tier switch
        {
            "tier 1" => "Tier 1",
            "tier 2" => "Tier 2",
            "tier 3" => "Tier 3",
            _ => "Unknown Tier",
        };

        CPH.SendAction(
            $"{gifter} gifted a {tierFormatted} subscription "
                + $"{(monthsGifted > 1 ? $"for {monthsGifted} months " : "")}"
                + $"to @{recipientUser}"
                + $"{(cumulativeMonths > 1 ? $", who's been subscribed for {cumulativeMonths} months!" : "")} "
                + $"{(!anonymous ? $"nycto97Hype1 They've given {totalSubsGifted} subscription{(totalSubsGifted > 1 ? "s" : "")} in the channel! nycto97Love1" : "nycto97Love1")}"
        );

        return true;
    }
}
