using System;
using System.Globalization;
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
        CPH.TryGetArg("tipUsername", out string tipUsername);
        CPH.TryGetArg("tipCurrency", out string tipCurrency);
        CPH.TryGetArg("tipAmount", out float tipAmount);
        CPH.TryGetArg("tipMessage", out string tipMessage);

        string tipAmountFormatted = tipAmount.ToString("F2", CultureInfo.InvariantCulture);

        string tipMessageFormatted = !string.IsNullOrEmpty(tipMessage)
            ? $" - \"{tipMessage}\" -"
            : "";

        if (tipAmount >= 1 && tipAmount < 5)
        {
            CPH.SendAction(
                $"{tipUsername} tipped {tipCurrency} {tipAmountFormatted}! nycto97Hype1{tipMessageFormatted} Thank you! nycto97Love1"
            );
        }
        else if (tipAmount >= 5 && tipAmount < 10)
        {
            CPH.SendAction(
                $"{tipUsername} threw {tipCurrency} {tipAmountFormatted} in my piggy bank! nycto97Hype1{tipMessageFormatted} Thank you for supporting me! nycto97Love1"
            );
        }
        else if (tipAmount >= 10 && tipAmount < 20)
        {
            CPH.SendAction(
                $"{tipUsername} supported me by donating {tipCurrency} {tipAmountFormatted}! nycto97Hype1{tipMessageFormatted} Thank you very much! nycto97Love1"
            );
        }
        else if (tipAmount >= 20 && tipAmount < 50)
        {
            CPH.SendAction(
                $"{tipUsername} donated {tipCurrency} {tipAmountFormatted}!!! nycto97Hype1{tipMessageFormatted} Thank you so much for your support! nycto97Love1"
            );
        }
        else if (tipAmount >= 50 && tipAmount < 100)
        {
            CPH.SendAction(
                $"{tipUsername} is an actual superhero and donated {tipCurrency} {tipAmountFormatted}!!! nycto97Hype1{tipMessageFormatted} Thank you for your massive support! nycto97Love1"
            );
        }
        else if (tipAmount >= 100)
        {
            CPH.SendAction(
                $"{tipUsername} is an absolute legend and donated {tipCurrency} {tipAmountFormatted}!!! nycto97RIP1{tipMessageFormatted} Thank you so so so much! nycto97Love1"
            );
        }

        return true;
    }
}
