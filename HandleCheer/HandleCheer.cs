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
        CPH.TryGetArg("user", out string user);
        CPH.TryGetArg("bits", out int amount);
        CPH.TryGetArg("messageCheermotesStripped", out string messageCheermotesStripped);

        string amountFormatted = amount.ToString("N0", CultureInfo.InvariantCulture);

        string messageCheermotesStrippedFormatted = !string.IsNullOrEmpty(messageCheermotesStripped)
            ? $" - \"{messageCheermotesStripped}\" -"
            : "";

        if (amount == 1)
        {
            CPH.SendMessage(
                $"@{user} dropped {amountFormatted} bit! nycto97Hype1{messageCheermotesStrippedFormatted} Thank you, it helps quite a... bit! nycto97LOL1"
            );
        }
        else if (amount >= 2 && amount < 50)
        {
            CPH.SendMessage(
                $"@{user} cheered {amountFormatted} bits! nycto97Hype1{messageCheermotesStrippedFormatted} Thanks for the bits! nycto97Love1"
            );
        }
        else if (amount == 50)
        {
            CPH.SendMessage(
                $"@{user} is taking me to the Candy Shop with their {amountFormatted} bits! nycto97Hype1{messageCheermotesStrippedFormatted} Thanks for the bits, shorty! nycto97Love1"
            );
        }
        else if (amount >= 51 && amount < 100)
        {
            CPH.SendMessage(
                $"@{user} cheered {amountFormatted} bits! nycto97Hype1{messageCheermotesStrippedFormatted} Thanks for the bits! nycto97Love1"
            );
        }
        else if (amount == 100)
        {
            CPH.SendMessage(
                $"@{user} gave me a dollar by cheering {amountFormatted} bits! nycto97Hype1{messageCheermotesStrippedFormatted} Thanks for the dollar! nycto97Love1"
            );
        }
        else if (amount >= 101 && amount < 500)
        {
            CPH.SendMessage(
                $"@{user} cheered {amountFormatted} bits! nycto97Hype1{messageCheermotesStrippedFormatted} Thanks for the bits! nycto97Love1"
            );
        }
        else if (amount >= 500 && amount < 1000)
        {
            CPH.SendMessage(
                $"@{user} is dropping bit-bombs! They've cheered {amountFormatted} bits!!! nycto97Hype1{messageCheermotesStrippedFormatted} Thanks for the bits! nycto97Love1"
            );
        }
        else if (amount >= 1000 && amount < 5000)
        {
            CPH.SendMessage(
                $"@{user} threw a bag full of bits! They've cheered {amountFormatted} bits!!! nycto97Hype1{messageCheermotesStrippedFormatted} Thanks for the bits! nycto97Love1"
            );
        }
        else
        {
            CPH.SendMessage(
                $"@{user} dropped a crate! They've cheered {amountFormatted} bits!!! nycto97Hype1{messageCheermotesStrippedFormatted} Thanks for the bits! nycto97Love1"
            );
        }

        return true;
    }
}
