using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ObjetosPerdidosMVC.Helpers
{
    public static class CallApiHelper
    {
        public static async Task<string> GetAsync(string uri)
        {
            HttpClient client = new HttpClient();

            string content = await client.GetStringAsync(uri);
            client.Dispose();
            return content;
        }
        public static string GetUri(string nameService)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            string endPoint = configuration.GetValue<string>(nameService);

            return endPoint;
        }
    }
}
