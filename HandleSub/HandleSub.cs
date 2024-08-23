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
        CPH.TryGetArg("tier", out string tier);

        string tierFormatted = tier switch
        {
            "prime" => "Prime",
            "tier 1" => "Tier 1",
            "tier 2" => "Tier 2",
            "tier 3" => "Tier 3",
            _ => "Unknown Tier",
        };

        CPH.SendAction(
            $"@{user} subscribed with {tierFormatted}! nycto97Hype1 Thank you for supporting the stream! nycto97Love1"
        );

        return true;
    }
}
