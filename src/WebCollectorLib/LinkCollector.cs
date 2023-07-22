using System;
using System.Threading.Tasks;
using System.Linq; 

namespace WebCollectorLib
{
    class LinkCollector
    {
        private readonly RawCollector _rawCollector;
        private readonly WebsiteParser _websiteParser;

        public LinkCollector()
        {
            _rawCollector = new RawCollector();
            _websiteParser = new WebsiteParser();
        }

        public async Task<string[]> FindLinks(string keyword)
        {
            try
            {
                string articleUrl = _websiteParser.BuildLinkPath(keyword);
                string htmlContent = await _rawCollector.DownloadRawHtml(articleUrl);

                var articleLinks = _websiteParser.FindLinks(htmlContent);
                return articleLinks.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding links: {ex.Message}");
                return null;
            }
        }
    }   
}