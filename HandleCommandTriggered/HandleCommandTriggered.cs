using System;
using System.Linq;
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
        CPH.TryGetArg("commandId", out Guid commandId);
        CPH.TryGetArg("rawInput", out string rawInput);
        CPH.TryGetArg("user", out string user);
        CPH.TryGetArg("userId", out string userId);
        CPH.TryGetArg("broadcastUserName", out string broadcastUserName);

        // Need 'Twitch Add target info' sub-action for these
        CPH.TryGetArg("targetUser", out string targetUser);
        CPH.TryGetArg("targetUserId", out string targetUserId);

        string commandIdString = commandId.ToString();

        switch (commandIdString)
        {
            // Utilities

            case "a05dbd68-79a0-4d5f-91fc-ac152b3ba70a": // Clip
                CPH.CreateClip();

                CPH.Wait(5000);

                CPH.TryGetArg("createClipSuccess", out bool createClipSuccess);

                if (createClipSuccess == false)
                {
                    CPH.SendMessage($"@{user} Failed to create clip TearGlove");

                    break;
                }

                CPH.TryGetArg("createClipUrl", out string createClipUrl);

                if (string.IsNullOrEmpty(createClipUrl))
                {
                    CPH.SendMessage(
                        $"@{user} Successfully created clip but failed to get the URL. You should find the clip at https://www.twitch.tv/{broadcastUserName}/clips?filter=clips&range=7d"
                    );
                }
                else
                {
                    CPH.SendMessage($"@{user} Successfully created clip -> {createClipUrl}");
                }

                break;

            case "e8a6ee0f-ca05-42dd-bf55-6f88423c629c": // Emote test
                CPH.SendMessage(
                    $"@{user} Please verify you can see these emotes: peepoRun (BetterTTV emote) | Chadge (FrankerFaceZ emote) | o7 (7TV emote)"
                );

                break;

            case "64fe6caf-1fab-46eb-aeeb-17558db811ca": // Shoutout
                if (string.IsNullOrEmpty(rawInput))
                {
                    CPH.SendMessage($"@{user} No user provided -> Usage: !shoutout/!so @user/user");

                    break;
                }

                if (string.IsNullOrEmpty(targetUserId))
                {
                    CPH.SendMessage($"@{user} User doesn't exist TearGlove");

                    break;
                }

                CPH.TwitchSendShoutoutById(targetUserId);

                CPH.Wait(1500);

                /*
                    I currently don't have a way to check whether the user ever streamed.
                    You can go live without a title and without a category...
                */

                // Need 'Twitch Add target info' sub-action for these
                CPH.TryGetArg("targetUserName", out string targetUserName);
                CPH.TryGetArg("targetChannelTitle", out string targetChannelTitle);
                CPH.TryGetArg("game", out string targetGame);

                string messagePrefix = $"BIG shoutout to @{targetUser} nycto97Love1";

                if (string.IsNullOrEmpty(targetChannelTitle) && string.IsNullOrEmpty(targetGame))
                {
                    CPH.SendMessage(
                        $"{messagePrefix} You can find them over at twitch.tv/{targetUserName} nycto97Hype1"
                    );
                }
                else if (string.IsNullOrEmpty(targetGame))
                {
                    CPH.SendMessage(
                        $"{messagePrefix} They last streamed \"{targetChannelTitle}\" over at twitch.tv/{targetUserName} nycto97Hype1"
                    );
                }
                else if (string.IsNullOrEmpty(targetChannelTitle))
                {
                    CPH.SendMessage(
                        $"{messagePrefix} They last were doing {targetGame} over at twitch.tv/{targetUserName} nycto97Hype1"
                    );
                }
                else
                {
                    CPH.SendMessage(
                        $"{messagePrefix} They last streamed \"{targetChannelTitle}\" and were doing {targetGame} over at twitch.tv/{targetUserName} nycto97Hype1"
                    );
                }

                break;

            // =================================================================

            // Fun

            case "5615e33a-0713-46ca-8e0c-6edcfb0402dd": // Bonk
            case "58bd9d11-0f89-4cfc-80bd-0de6f5304982": // Hug
            case "a49297a7-73cb-4071-b84d-c3a9b69ef74b": // Kiss
            case "009c93bd-dff1-4617-b667-94ca27648dec": // Lick
            case "2664ddf0-06e1-4e04-a690-63ba11b4dd6b": // Smash
                string action = commandIdString switch
                {
                    "5615e33a-0713-46ca-8e0c-6edcfb0402dd" => "bonks",
                    "58bd9d11-0f89-4cfc-80bd-0de6f5304982" => "hugs",
                    "a49297a7-73cb-4071-b84d-c3a9b69ef74b" => "kisses",
                    "009c93bd-dff1-4617-b667-94ca27648dec" => "licks",
                    "2664ddf0-06e1-4e04-a690-63ba11b4dd6b" => "smashes",
                    _ => "undefined action",
                };

                string suffix = commandIdString switch
                {
                    "5615e33a-0713-46ca-8e0c-6edcfb0402dd" => "horniness",
                    "58bd9d11-0f89-4cfc-80bd-0de6f5304982" => "love",
                    "a49297a7-73cb-4071-b84d-c3a9b69ef74b" => "passion",
                    "009c93bd-dff1-4617-b667-94ca27648dec" => "wetness",
                    "2664ddf0-06e1-4e04-a690-63ba11b4dd6b" => "strength",
                    _ => "undefined suffix",
                };

                string emote = commandIdString switch
                {
                    "5615e33a-0713-46ca-8e0c-6edcfb0402dd" => "nycto97LOL1",
                    "58bd9d11-0f89-4cfc-80bd-0de6f5304982" => "nycto97Love1",
                    "a49297a7-73cb-4071-b84d-c3a9b69ef74b" => "nycto97Love1",
                    "009c93bd-dff1-4617-b667-94ca27648dec" => "nycto97LOL1",
                    "2664ddf0-06e1-4e04-a690-63ba11b4dd6b" => "nycto97RIP1",
                    _ => "undefined emote",
                };

                string soundFileName = commandIdString switch
                {
                    "5615e33a-0713-46ca-8e0c-6edcfb0402dd" => "Bonk - Sound Effect (HD).mp3",
                    "58bd9d11-0f89-4cfc-80bd-0de6f5304982" => "Hug-Clothes-Pat_on_the_Back-6.mp3",
                    "a49297a7-73cb-4071-b84d-c3a9b69ef74b" => "smoochykiss.mp3",
                    "009c93bd-dff1-4617-b667-94ca27648dec" => "spong-lick.mp3",
                    "2664ddf0-06e1-4e04-a690-63ba11b4dd6b" => "punch-sound-effect.mp3",
                    _ => "undefined sound",
                };

                float volume = soundFileName switch
                {
                    "Bonk - Sound Effect (HD).mp3" => 0.1f,
                    "Hug-Clothes-Pat_on_the_Back-6.mp3" => 0.1f,
                    "smoochykiss.mp3" => 0.1f,
                    "spong-lick.mp3" => 0.1f,
                    "punch-sound-effect.mp3" => 0.1f,
                    _ => 0.1f,
                };

                Random random = new Random();
                int randomPercentage = random.Next(0, 101);

                if (string.IsNullOrEmpty(rawInput) || userId == targetUserId)
                {
                    CPH.SendMessage(
                        $"@{user} {action} themselves with {randomPercentage}% {suffix} {emote}"
                    );

                    CPH.PlaySound(@$"D:\jelle\Music\Twitch\Sounds\{soundFileName}", volume);

                    break;
                }

                if (string.IsNullOrEmpty(targetUserId))
                {
                    CPH.SendMessage($"@{user} User doesn't exist TearGlove");

                    break;
                }

                CPH.SendMessage(
                    $"@{user} {action} @{targetUser} with {randomPercentage}% {suffix} {emote}"
                );

                CPH.PlaySound(@$"D:\jelle\Music\Twitch\Sounds\{soundFileName}", volume);

                break;

            case "06fdc6ff-62cd-4257-ac05-e09503aa4b6a": // Lurk
                CPH.SendMessage(
                    $"Thanks for lurking @{user} nycto97Wave1{(!string.IsNullOrEmpty(rawInput) ? $" - \"{rawInput}\" -" : "")} I appreciate your presence! nycto97Love1"
                );

                break;

            case "baf03811-5f49-4237-bcae-a21d39bbd1c0": // Unlurk
                CPH.SendMessage(
                    $"Welcome back @{user} nycto97Wave1{(!string.IsNullOrEmpty(rawInput) ? $" - \"{rawInput}\" -" : "")} I'm glad you're still here! nycto97Love1"
                );

                break;

            case "303ccc43-3191-4b52-a04c-9b4dd3fa8066": // Vanish
                CPH.TryGetArg("broadcastUserId", out string broadcastUserId);

                if (userId == broadcastUserId)
                {
                    CPH.SendMessage(
                        $"@{user} Ayo streamer guy, nuh-uuuh.. You ain't going nowhere boii"
                    );

                    break;
                }

                CPH.TryGetArg("isModerator", out bool isModerator);

                int timeoutInSeconds = isModerator ? 10 : 20;
                bool timeoutAsBot = !isModerator;
                string reason =
                    $"Vanished (Reload page if timeout persists after {timeoutInSeconds} seconds and shows as -1 seconds)";

                CPH.TryGetArg("userName", out string userName);

                CPH.TwitchTimeoutUser(userName, timeoutInSeconds, reason, timeoutAsBot);

                CPH.PlaySound(@"D:\jelle\Music\Twitch\Sounds\Vanish Sound Effect.mp3", 0.1f);

                CPH.Wait(1000);

                CPH.SendMessage("o7");

                if (isModerator)
                {
                    CPH.Wait(timeoutInSeconds * 1000); // Don't account for the 1 second delay earlier, use it as buffer

                    CPH.TwitchAddModerator(userName);

                    CPH.SendAction($"re-added @{user} as moderator", false);
                }

                break;

            // =================================================================

            // Sounds

            case "3cb1427d-31b8-4c44-b227-37059c7542cf": // Badum tss
                CPH.PlaySound(@"D:\jelle\Music\Twitch\Sounds\Ba Dum Tss (Sound Effect).mp3", 0.07f);

                break;

            case "9bba8f00-a82e-4cc7-ab81-bcff9e85de8a": // Quack
                CPH.PlaySound(@"D:\jelle\Music\Twitch\Sounds\075176_duck-quack-40345.mp3", 0.05f);

                break;

            // =================================================================

            // Raid Messages

            case "9ffc9124-e32e-4d67-a89f-85eaf9b2edc2": // Non subs
                CPH.SendMessage(
                    string.Join(" ", Enumerable.Repeat("twitchRaid Nycto TombRaid", 15)),
                    false
                );

                break;

            case "8e1cdcc0-5ea3-4640-aca4-2ca7c91fb85b": // Subs
                CPH.SendMessage(
                    string.Join(" ", Enumerable.Repeat("nycto97Hype Nycto TombRaid", 15)),
                    false
                );

                break;

            // =================================================================

            // Socials/accounts/links

            case "6a8c226d-c040-4e18-8f46-6daba6e2b48f": // Blizzard/Battle.net
                CPH.SendMessage("Blizzard / Battle.net -> Nycto#21256 🎮");

                break;

            case "e3c23b9c-ed27-494b-a7c6-8fe99b20a0c1": // Call of Duty/Activision
                CPH.SendMessage("Call of Duty / Activision -> Nycto#5536049 🎮");

                break;

            case "ec1c33ab-6b56-4153-a10f-c53fd083deed": // Counter-strike skins
                CPH.SendMessage(
                    "CounterStrike2 Skins -> steamcommunity.com/id/Nycto97/inventory/#730 🔫"
                );

                break;

            case "9adb405a-c250-4ef6-99ca-811a54f72dfa": // Discord
                CPH.SendMessage("Discord -> discord.gg/Y2fat6v 💜");

                break;

            case "65cddd4d-de0f-4f50-868a-26f6b6faadce": // EA/Origin
                CPH.SendMessage("EA / Origin -> Nycto1337 🎮");

                break;

            case "5561535f-e460-4c7d-84a3-f36baab3face": // Epic Games
                CPH.SendMessage("EpicGames -> Nycto97 🎮");

                break;

            case "80328fd5-620f-4808-a6ed-7598561ba685": // Facebook
                CPH.SendMessage("Facebook -> facebook.com/Nycto1337 💙");

                break;

            case "ff683f2e-c906-4de1-bdb7-d1742ad64c50": // Instagram
                CPH.SendMessage("Instagram -> instagram.com/Nycto97 💗");

                break;

            case "df11f4ea-42c5-48a1-8dfa-65cd7beceab1": // PlayStation
                CPH.SendMessage("PlayStation (PSN) -> Nycto97 🎮");

                break;

            case "34bb5dbe-684c-4cbc-8f6c-ad976d30f709": // Riot Games
                CPH.SendMessage("RiotGames -> Nycto#0420 🎮");

                break;

            case "2bead345-45e0-4a6c-9891-d21a60a02559": // Socials
                CPH.SendMessage("Socials -> linktr.ee/Nycto97 ✨");

                break;

            case "5d12757f-7fd7-4109-9fb7-e933dd636729": // Steam
                CPH.SendMessage("Steam -> steamcommunity.com/id/Nycto97 🎮");

                break;

            case "54714415-aa5f-4315-80d4-46c9a8f96866": // TikTok
                CPH.SendMessage("TikTok -> tiktok.com/@Nycto1337 💗");

                break;

            case "a30e24f3-55ad-4f88-80a6-376fb83e2ef8": // Tip/donate
                CPH.SendMessage(
                    $"Tip/donate -> streamelements.com/{broadcastUserName}/tip nycto97Hype1 @{user} only tip what you can afford, I don't want you to get in trouble! nycto97Love1"
                );

                break;

            case "6fbcbdf7-7203-4861-8f9a-bdc82c40424a": // Twitter/X
                CPH.SendMessage("Twitter (X) -> twitter.com/Nycto97 💙");

                break;

            case "8013b569-e4f3-432c-b0da-16cc08822561": // Ubisoft
                CPH.SendMessage("Ubisoft -> Nycto1337 🎮");

                break;

            case "fc078460-677e-4529-93ec-46b666d35dfc": // Xbox
                CPH.SendMessage("Xbox -> Nycto97 🎮");

                break;

            case "6c534184-d7af-4174-b585-5c57c5a0ab94": // YouTube
                CPH.SendMessage("YouTube -> youtube.com/Nycto97 🎬");

                break;

            // =================================================================
        }

        return true;
    }
}
