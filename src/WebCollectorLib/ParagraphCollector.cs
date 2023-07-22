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

        public async Task<List<string>> ExtractParagraphsFromLinks(string[] links)
        {
            try
            {
                List<Task<List<string>>> tasks = new List<Task<List<string>>>();

                foreach (string link in links)
                {
                    string realLink = "https://www.deraktionaer.de" + link;
                    Task<List<string>> task = ExtractParagraphsFromLink(realLink);
                    tasks.Add(task);
                }

                List<string> paragraphs = new List<string>();

                while (tasks.Count > 0)
                {
                    Task<List<string>> completedTask = await Task.WhenAny(tasks);
                    tasks.Remove(completedTask);
                    List<string> extractedParagraphs = await completedTask;
                    paragraphs.AddRange(extractedParagraphs);
                }

                return paragraphs;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting paragraphs: {ex.Message}");
                return null;
            }
        }

        private async Task<List<string>> ExtractParagraphsFromLink(string link)
        {
            List<string> paragraphs = new List<string>();

            try
            {
                string htmlContent = await _rawCollector.DownloadRawHtml(link);
                var extractedParagraphs = _websiteParser.FindParagraphs(htmlContent);
                paragraphs.AddRange(extractedParagraphs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting paragraphs from link: {ex.Message}");
            }

            return paragraphs;
        }
    }   
}