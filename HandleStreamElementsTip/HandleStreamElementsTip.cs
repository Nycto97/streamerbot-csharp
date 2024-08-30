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
        CPH.TryGetArg("tipUsername", out string username);
        CPH.TryGetArg("tipCurrency", out string currencyCode);
        CPH.TryGetArg("tipAmount", out float amount);
        CPH.TryGetArg("tipMessage", out string message);

        string amountFormatted = amount.ToString("N2", CultureInfo.InvariantCulture);

        string messageFormatted = !string.IsNullOrEmpty(message) ? $" - \"{message}\" -" : "";

        if (amount >= 1 && amount < 5)
        {
            CPH.SendAction(
                $"{username} tipped {currencyCode} {amountFormatted}! nycto97Hype1{messageFormatted} Thank you! nycto97Love1"
            );
        }
        else if (amount >= 5 && amount < 10)
        {
            CPH.SendAction(
                $"{username} threw {currencyCode} {amountFormatted} in my piggy bank! nycto97Hype1{messageFormatted} Thank you for supporting me! nycto97Love1"
            );
        }
        else if (amount >= 10 && amount < 20)
        {
            CPH.SendAction(
                $"{username} supported me by donating {currencyCode} {amountFormatted}! nycto97Hype1{messageFormatted} Thank you very much! nycto97Love1"
            );
        }
        else if (amount >= 20 && amount < 50)
        {
            CPH.SendAction(
                $"{username} donated {currencyCode} {amountFormatted}!!! nycto97Hype1{messageFormatted} Thank you so much for your support! nycto97Love1"
            );
        }
        else if (amount >= 50 && amount < 100)
        {
            CPH.SendAction(
                $"{username} is an actual superhero and donated {currencyCode} {amountFormatted}!!! nycto97Hype1{messageFormatted} Thank you for your massive support! nycto97Love1"
            );
        }
        else if (amount >= 100)
        {
            CPH.SendAction(
                $"{username} is an absolute legend and donated {currencyCode} {amountFormatted}!!! nycto97RIP1{messageFormatted} Thank you so so so much! nycto97Love1"
            );
        }

        return true;
    }
}
