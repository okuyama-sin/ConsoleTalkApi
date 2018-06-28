using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;

namespace talkapiconsoletest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("文字を入力してください。");
            string talk = Console.ReadLine();
            byte[] jsonb = Task.Run(() => HttpPost(talk)).Result;
            string json = Encoding.UTF8.GetString(jsonb);


            string reply = (string)jobj["results"][0]["reply"];
            Console.WriteLine(reply);
        }

        public static async Task<byte[]> HttpPost(string talk)
        {
            string url = "https://api.a3rt.recruit-tech.co.jp/talk/v1/smalltalk";

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"apikey","内緒" },
                {"query",talk }
            });

            var hc = new HttpClient();

            var response = await hc.PostAsync(url, content);

            return await response.Content.ReadAsByteArrayAsync();
        }
    }