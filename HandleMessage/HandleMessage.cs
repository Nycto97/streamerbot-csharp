using System;
using System.Collections.Generic;
using System.IO;
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
    private HashSet<string> tldHashSet;

    public void Init()
    {
        string filePath = "G:/Coding/Coding/tlds-alpha-by-domain.txt";
        tldHashSet = new HashSet<string>();

        foreach (string line in File.ReadLines(filePath))
        {
            string trimmed = line.Trim();
            if (!trimmed.StartsWith("#") && !string.IsNullOrWhiteSpace(trimmed))
            {
                tldHashSet.Add(trimmed.ToUpperInvariant());
            }
        }
    }

    public bool Execute()
    {
        CPH.TryGetArg("user", out string user);
        CPH.TryGetArg("userId", out string userId);
        CPH.TryGetArg("message", out string message);

        string seryBotUserId = CPH.GetGlobalVar<string>("seryBotUserId");

        if (userId == seryBotUserId && message.StartsWith($"{user} has joined"))
        {
            CPH.SendMessage("good bot");

            return true;
        }

        CPH.TryGetArg("broadcastUserId", out string broadcastUserId);
        CPH.TryGetArg("isModerator", out bool isModerator);
        CPH.TryGetArg("isVip", out bool isVip);

        if (!(userId == broadcastUserId || isModerator || isVip) && ContainsUrl(message))
        {
            DateTime currentTime = DateTime.Now;
            DateTime permit =
                CPH.GetTwitchUserVarById<DateTime?>(userId, "linkPermitExpiration") ?? currentTime;

            bool hasPermit = permit > currentTime;

            CPH.UnsetTwitchUserVarById(userId, "linkPermitExpiration");

            if (!hasPermit)
            {
                CPH.TryGetArg("msgId", out string messageId);

                CPH.TwitchDeleteChatMessage(messageId);

                CPH.SendMessage(
                    $"@{user} Whoops! Only Mods and VIPs can post links nycto97RIP1 Please ask permission first nycto97Love1"
                );

                return true;
            }
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

    private bool ContainsUrl(string message)
    {
        string pattern =
            @"(http:\/\/|https:\/\/)?[a-zA-Z0-9]+(\.[a-zA-Z0-9]+)*\.([a-zA-Z0-9]{1,10})((\/+)[^\/ ]*)*";

        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        Match matches = regex.Match(message);

        return regex.IsMatch(message) && tldHashSet.Contains(matches.Groups[3].Value.ToUpper());
    }
}
