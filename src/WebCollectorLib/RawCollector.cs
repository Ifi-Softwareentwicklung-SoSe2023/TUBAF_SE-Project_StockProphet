using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;


namespace WebCollectorLib
{
    public class RawCollector
    {
        private readonly HttpClient _client;

        public RawCollector()
        {
            _client = new HttpClient();
        }

        public async Task<string> DownloadRawHtml(string url)
        {
            try
            {
                return await _client.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading raw HTML: {ex.Message}");
                return null;
            }
        }
    }
}