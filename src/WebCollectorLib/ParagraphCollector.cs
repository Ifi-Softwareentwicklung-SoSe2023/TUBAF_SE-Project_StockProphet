using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebCollectorLib
{
    public class ParagraphCollector
    {
        private readonly RawCollector _rawCollector;
        private readonly WebsiteParser _websiteParser;

        public ParagraphCollector()
        {
            _rawCollector = new RawCollector();
            _websiteParser = new WebsiteParser();
        }

        public List<string> ExtractParagraphsFromLinks(string link)
        {
            try
            {
                List<string> paragraphs = new List<string>();
                string realLink = "https://www.deraktionaer.de" + link;
                string htmlContent = _rawCollector.DownloadRawHtml(realLink);
                var extractedParagraphs = _websiteParser.FindParagraphs(htmlContent);
                paragraphs.AddRange(extractedParagraphs);
                return paragraphs;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting paragraphs: {ex.Message}");
                return null;
            }
        }
    }

}