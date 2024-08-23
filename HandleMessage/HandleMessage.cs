using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        CPH.TryGetArg("user", out string user);
        CPH.TryGetArg("message", out string message);

        if (userName == "sery_bot" && message.StartsWith("Sery_Bot has joined"))
        {
            CPH.SendMessage("good bot");

            return true;
        }

        // Sounds (keep at bottom of file because execution stops until sound is played (3rd argument is true))

        List<(int Position, Action Action)> actions = new List<(int, Action)>();

        foreach (Match match in Regex.Matches(message, @"\b(?:AYAYA|nanaAYAYA)\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () =>
                        CPH.PlaySound(
                            @"D:\jelle\Music\Twitch\Sounds\kiniro-mosaic-ayaya-ayaya.mp3",
                            0.1f,
                            true
                        )
                )
            );
        }

        foreach (Match match in Regex.Matches(message, @"\bBLABBERING\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () => CPH.PlaySound(@"D:\jelle\Music\Twitch\Sounds\blahdi-blah.mp3", 0.1f, true)
                )
            );
        }

        foreach (Match match in Regex.Matches(message, @"\bBLELELE\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () => CPH.PlaySound(@"D:\jelle\Music\Twitch\Sounds\blebleble.mp3", 0.1f, true)
                )
            );
        }

        foreach (Match match in Regex.Matches(message, @"\bHUH\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () =>
                        CPH.PlaySound(
                            @"D:\jelle\Music\Twitch\Sounds\Huh sound effect.mp3",
                            0.1f,
                            true
                        )
                )
            );
        }

        foreach (Match match in Regex.Matches(message, @"\bMONKE\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () => CPH.PlaySound(@"D:\jelle\Music\Twitch\Sounds\monkey-gaga.mp3", 0.1f, true)
                )
            );
        }

        foreach (Match match in Regex.Matches(message, @"\bOOOO\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () =>
                        CPH.PlaySound(
                            @"D:\jelle\Music\Twitch\Sounds\the-rap-battle-parody-oh.mp3",
                            0.1f,
                            true
                        )
                )
            );
        }

        foreach (Match match in Regex.Matches(message, @"\bok\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () =>
                        CPH.PlaySound(
                            @"D:\jelle\Music\Twitch\Sounds\Okay (Meme Sound) - Sound Effect for editing.mp3",
                            0.1f,
                            true
                        )
                )
            );
        }

        foreach (Match match in Regex.Matches(message, @"\bREEE\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () =>
                        CPH.PlaySound(
                            @"D:\jelle\Music\Twitch\Sounds\reeeeeeeeeeeeee.mp3",
                            0.1f,
                            true
                        )
                )
            );
        }

        foreach (Match match in Regex.Matches(message, @"\bSUSSY\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () =>
                        CPH.PlaySound(
                            @"D:\jelle\Music\Twitch\Sounds\Vine Boom Sound Effect.mp3",
                            0.1f,
                            true
                        )
                )
            );
        }

        foreach (Match match in Regex.Matches(message, @"\b(?:vibbleUwU|sunshi174Hannuwu)\b"))
        {
            actions.Add(
                (
                    match.Index,
                    () => CPH.PlaySound(@"D:\jelle\Music\Twitch\Sounds\uwu-hannah.mp3", 0.1f, true)
                )
            );
        }

        // Sort actions by their position in the message
        actions.Sort((a, b) => a.Position.CompareTo(b.Position));

        // Execute actions in order
        foreach (var action in actions)
        {
            action.Action();
        }

        return true;
    }
}
