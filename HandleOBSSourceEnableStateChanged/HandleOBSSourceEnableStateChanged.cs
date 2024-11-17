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
        CPH.TryGetArg("obsEvent.sceneName", out string sceneName);
        CPH.TryGetArg("obsEvent.sceneItemId", out int sceneItemId);
        CPH.TryGetArg("obsEvent.sceneItemEnabled", out bool sourceEnabled);

        // Hide Webcam 720p in Small Cam + Follower Goal group when Small Cam + Follower Goal group gets hidden
        if (
            (sceneName == "🔴 GAME" && sceneItemId == 33)
            || (sceneName == "🔴 MARBLES" && sceneItemId == 37)
        )
        {
            if (!sourceEnabled)
            {
                CPH.Wait(3000);
            }

            // Game scene enough since webcam also shows/hides in Marbles scene because of the group
            CPH.ObsSetSourceVisibility("🔴 GAME", "Webcam 720p", sourceEnabled);
        }
        // Hide Small Cam + Follower Goal group when Be Right Back Group Marbles gets shown
        else if (sceneName == "🔴 MARBLES" && sceneItemId == 43 && sourceEnabled)
        {
            CPH.ObsSetSourceVisibility("🔴 MARBLES", "Small Cam + Follower Goal", false);
        }
        else if (
            // Spotify Song Panel
            (sceneName == "🔴 TALK [Camera]" && sceneItemId == 19)
            || (sceneName == "🔴 GAME" && sceneItemId == 27)
            || (sceneName == "🔴 MARBLES" && sceneItemId == 29)
            || (sceneName == "🔴 BE RIGHT BACK" && sceneItemId == 16)
            || (sceneName == "🔴 TALK [Main Monitor]" && sceneItemId == 20)
            || (sceneName == "🔴 START" && sceneItemId == 13)
            || (sceneName == "🔴 END" && sceneItemId == 11)
        )
        {
            if (!sourceEnabled)
            {
                // Hide Spotify Song Panel in all scenes
                CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 GAME", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 MARBLES", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 START", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 END", "Spotify SONG", false);
            }
            else
            {
                // Hide iTunes Song Panel in all scenes
                CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 GAME", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 MARBLES", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 START", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 END", "iTunes SONG", false);

                // Show Spotify Song Panel in all scenes
                CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "Spotify SONG", true);
                CPH.ObsSetSourceVisibility("🔴 GAME", "Spotify SONG", true);
                CPH.ObsSetSourceVisibility("🔴 MARBLES", "Spotify SONG", true);
                CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "Spotify SONG", true);
                CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "Spotify SONG", true);
                CPH.ObsSetSourceVisibility("🔴 START", "Spotify SONG", true);
                CPH.ObsSetSourceVisibility("🔴 END", "Spotify SONG", true);
            }
        }
        else if (
            // iTunes Song Panel
            (sceneName == "🔴 TALK [Camera]" && sceneItemId == 14)
            || (sceneName == "🔴 GAME" && sceneItemId == 23)
            || (sceneName == "🔴 MARBLES" && sceneItemId == 7)
            || (sceneName == "🔴 BE RIGHT BACK" && sceneItemId == 15)
            || (sceneName == "🔴 TALK [Main Monitor]" && sceneItemId == 18)
            || (sceneName == "🔴 START" && sceneItemId == 11)
            || (sceneName == "🔴 END" && sceneItemId == 10)
        )
        {
            if (!sourceEnabled)
            {
                // Hide iTunes Song Panel in all scenes
                CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 GAME", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 MARBLES", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 START", "iTunes SONG", false);
                CPH.ObsSetSourceVisibility("🔴 END", "iTunes SONG", false);
            }
            else
            {
                // Hide Spotify Song Panel in all scenes
                CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 GAME", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 MARBLES", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 START", "Spotify SONG", false);
                CPH.ObsSetSourceVisibility("🔴 END", "Spotify SONG", false);

                // Show iTunes Song Panel in all scenes
                CPH.ObsSetSourceVisibility("🔴 TALK [Camera]", "iTunes SONG", true);
                CPH.ObsSetSourceVisibility("🔴 GAME", "iTunes SONG", true);
                CPH.ObsSetSourceVisibility("🔴 MARBLES", "iTunes SONG", true);
                CPH.ObsSetSourceVisibility("🔴 BE RIGHT BACK", "iTunes SONG", true);
                CPH.ObsSetSourceVisibility("🔴 TALK [Main Monitor]", "iTunes SONG", true);
                CPH.ObsSetSourceVisibility("🔴 START", "iTunes SONG", true);
                CPH.ObsSetSourceVisibility("🔴 END", "iTunes SONG", true);
            }
        }

        return true;
    }
}
