using Notify;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Slack
{
    public class BotNotifier : INotify<Payload, Error>, IDisposable
    {
        RateLimit Limit = new RateLimit(1000);

        HttpClient Client;
        
        /// <summary>
        /// Botトークン
        /// </summary>
        string Token;

        public BotNotifier(string token)
        {
            Token = token;
            Client = new HttpClient();

        }

        public void Dispose()
        {
            Client.Dispose();
        }

        protected string MakeJsonPayload<T>(T p)
        {
            var options = new JsonSerializerOptions { IncludeFields = true };
            var json = JsonSerializer.Serialize(p, options);
            return json;
        }

        /// <summary>
        /// 通知を行う
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="Exception"></exception>
        public Error Push(Payload message)
        {
            Limit.Invoke();

            var json = MakeJsonPayload(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "https://slack.com/api/chat.postMessage");
            request.Content = content;
            request.Headers.Add("Authorization", $"Bearer {Token}");

            var ret = Client.SendAsync(request);

            ret.Wait();

            var r2 = ret.Result.Content.ReadAsStream();

            Error err = JsonSerializer.Deserialize<Error>(r2);
            if (err?.ok != true &&  err != null && err.error != "missing_post_type")
            {
                throw new Exception($"{err?.error}");
            }
            return err;
        }
    }
}
