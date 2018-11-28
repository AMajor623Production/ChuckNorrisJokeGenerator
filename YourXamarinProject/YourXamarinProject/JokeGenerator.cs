using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace YourXamarinProject
{
    public class JokeGenerator
    {
        private readonly string apiUrl = "http://api.icndb.com/jokes/random/";
        private HttpClient client = new HttpClient();

        public async Task<string> GenerateJoke()
        {
            string response = await GetJokeResponseAsync();
            if (string.IsNullOrWhiteSpace(response))
            {
                return "Whoops! Couldn't generate Chuck Norris joke.";
            }

            string joke = ExtractJoke(response);

            return string.IsNullOrWhiteSpace(joke) ?
                "Hmm, no jokes available." :
                joke;
        }

        private string ExtractJoke(string jsonResponse)
        {
            string joke = string.Empty;

            JObject obj = JObject.Parse(jsonResponse);

            if (obj != null && obj["type"] != null)
            {
                string successStr = obj["type"].Value<string>();

                if (successStr.ToLower().Equals("success"))
                {
                    joke = obj["value"]?["joke"]?.Value<string>() ?? string.Empty;
                }
            }

            return joke;
        }

        private async Task<string> GetJokeResponseAsync()
        {
            string jokeResponse = await client.GetStringAsync(apiUrl);
            return jokeResponse;
        }
    }
}
