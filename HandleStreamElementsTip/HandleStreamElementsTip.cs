using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Streamer.bot.Plugin.Interface; // Remove in Streamer.bot
using Streamer.bot.Plugin.Interface.Enums; // Remove in Streamer.bot
using Streamer.bot.Plugin.Interface.Model; // Remove in Streamer.bot

/*
    Use this template for Streamer.bot C# code -> copy all code here and paste in Streamer.bot but remove
    marked 'using' Streamer.bot... and remove ": CPHInlineBase" out of "public class CPHInline : CPHInlineBase"
*/

public class CPHInline : CPHInlineBase // Remove ": CPHInlineBase" in Streamer.bot
{
    private static readonly HttpClient httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(30),
    };
    private const string apiUrl = "https://v6.exchangerate-api.com/v6/";

    public bool Execute()
    {
        CPH.TryGetArg("tipUsername", out string username);
        CPH.TryGetArg("tipCurrency", out string currencyCode);
        CPH.TryGetArg("tipAmount", out float amount);
        CPH.TryGetArg("tipMessage", out string message);

        string amountFormatted = amount.ToString("N2", CultureInfo.InvariantCulture);

        float amountInUSD = amount;
        string amountInUSDFormatted = "";

        string messageFormatted = !string.IsNullOrEmpty(message) ? $" - \"{message}\" -" : "";

        if (currencyCode != "USD")
        {
            float exchangeRateToUSD = GetExchangeRateToUSD(currencyCode).GetAwaiter().GetResult();

            amountInUSD = amount * exchangeRateToUSD;

            amountInUSDFormatted =
                $" ({amountInUSD.ToString("N2", CultureInfo.InvariantCulture)} USD)";
        }

        if (amountInUSD < 5)
        {
            CPH.SendAction(
                $"{username} tipped {amountFormatted} {currencyCode}{amountInUSDFormatted}! nycto97Hype1{messageFormatted} Thank you! nycto97Love1"
            );
        }
        else if (amountInUSD >= 5 && amountInUSD < 10)
        {
            CPH.SendAction(
                $"{username} threw {amountFormatted} {currencyCode}{amountInUSDFormatted} in my piggy bank! nycto97Hype1{messageFormatted} Thank you for supporting me! nycto97Love1"
            );
        }
        else if (amountInUSD >= 10 && amountInUSD < 20)
        {
            CPH.SendAction(
                $"{username} supported me by donating {amountFormatted} {currencyCode}{amountInUSDFormatted}! nycto97Hype1{messageFormatted} Thank you very much! nycto97Love1"
            );
        }
        else if (amountInUSD >= 20 && amountInUSD < 50)
        {
            CPH.SendAction(
                $"{username} donated {amountFormatted} {currencyCode}{amountInUSDFormatted}!!! nycto97Hype1{messageFormatted} Thank you so much for your support! nycto97Love1"
            );
        }
        else if (amountInUSD >= 50 && amountInUSD < 100)
        {
            CPH.SendAction(
                $"{username} is an actual superhero and donated {amountFormatted} {currencyCode}{amountInUSDFormatted}!!! nycto97Hype1{messageFormatted} Thank you for your massive support! nycto97Love1"
            );
        }
        else
        {
            CPH.SendAction(
                $"{username} is an absolute legend and donated {amountFormatted} {currencyCode}{amountInUSDFormatted}!!! nycto97RIP1{messageFormatted} Thank you so so so much! nycto97Love1"
            );
        }

        return true;
    }

    private async Task<float> GetExchangeRateToUSD(string currencyCode)
    {
        CPH.TryGetArg("exchangeRateApiApiKey", out string exchangeRateApiApiKey);

        try
        {
            string requestUrl = $"{apiUrl}{exchangeRateApiApiKey}/latest/{currencyCode}";
            HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseBody);
            float exchangeRate = (float)json["conversion_rates"]["USD"];

            return exchangeRate;
        }
        catch (Exception ex)
        {
            CPH.LogError($"Error fetching exchange rate: {ex.Message}");

            return 1.0f;
        }
    }
}
