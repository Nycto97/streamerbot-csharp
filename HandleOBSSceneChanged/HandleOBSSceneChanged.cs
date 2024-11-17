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
        CPH.ObsSetSourceVisibility("🔴 START", "Starting Soon Group", false);
        CPH.ObsSetSourceVisibility("🔴 START", "Timer Panel", false);
        CPH.ObsSetSourceVisibility("🔴 START", "Chat", false);

        CPH.ObsSetSourceVisibility("🔴 END", "Stream Ended Group", false);
        CPH.ObsSetSourceVisibility("🔴 END", "Thanks for Watching Panel", false);
        CPH.ObsSetSourceVisibility("🔴 END", "Chat", false);

        CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "Be Right Back Group", false);
        CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "Taking Short Break Group", false);
        CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "Chat", false);

        CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "Chat", false);
        CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "Follower Goal Talk Panel", false);

        CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "Webcam 720p Group", false);
        CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "Chat", false);
        CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "Follower Goal Talk Panel", false);

        CPH.TryGetArg("obs.sceneName", out string sceneName);

        switch (sceneName)
        {
            case "🔴 START":
                CPH.ObsSetSourceVisibility("🔴 START", "Starting Soon Group", true);
                CPH.Wait(2000);
                CPH.ObsSetSourceVisibility("🔴 START", "Timer Panel", true);
                CPH.Wait(2000);
                CPH.ObsSetSourceVisibility("🔴 START", "Chat", true);

                break;

            case "🔴 END":
                CPH.ObsSetSourceVisibility("🔴 END", "Stream Ended Group", true);
                CPH.Wait(2000);
                CPH.ObsSetSourceVisibility("🔴 END", "Thanks for Watching Panel", true);
                CPH.Wait(2000);
                CPH.ObsSetSourceVisibility("🔴 END", "Chat", true);

                break;

            case "🔴 BE RIGHT BACK":
                CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "Be Right Back Group", true);
                CPH.Wait(2000);
                CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "Taking Short Break Group", true);
                CPH.Wait(2000);
                CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "Chat", true);

                break;

            case "🔴 TALK [Camera]":
                CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "Chat", true);
                CPH.Wait(2000);
                CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "Follower Goal Talk Panel", true);

                break;

            case "🔴 TALK [Main Monitor]":
                CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "Webcam 720p Group", true);
                CPH.Wait(2000);
                CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "Chat", true);
                CPH.Wait(2000);
                CPH.ObsSetSourceVisibility(
                    "🔴 TALK [Main Monitor]",
                    "Follower Goal Talk Panel",
                    true
                );

                break;
        }

        return true;
    }
}
