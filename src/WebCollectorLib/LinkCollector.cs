using System;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;

namespace WebCollectorLib
{
    public class LinkCollector
    {
        private readonly RawCollector _rawCollector;
        private readonly IWebsiteParser _websiteParser;

        public LinkCollector(IWebsiteParser WebsiteParser)
        {
            _rawCollector = new RawCollector();
            _websiteParser = WebsiteParser;
        }

        public LinkCollector() : this(new WebsiteParser_1())
        {}

        public string[] FindLinks(string keyword)
        {
            try
            {
                string articleUrl = _websiteParser.BuildLinkPath(keyword);
                string htmlContent = _rawCollector.DownloadRawHtml(articleUrl);

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