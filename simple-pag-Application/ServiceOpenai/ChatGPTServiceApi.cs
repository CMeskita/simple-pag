using Newtonsoft.Json;
using System.Text;

namespace simple_pag_Application.ServiceOpenai
{
    public class ChatGPTServiceApi : IChatGPTServiceApi
    {
        string apikey = Environment.GetEnvironmentVariable("APIKEY_OPENAI") + "";
        string apiurl = "https://api.openai.com/v1/chat/completions";
        public async Task<string> ObterRespotaChatGpt(string prompt)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apikey}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    Messages = new[]
                    {
                    new{ role="user", content=prompt}
                    },
                    max_tokens = 100
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiurl, content);
                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
    }
}
