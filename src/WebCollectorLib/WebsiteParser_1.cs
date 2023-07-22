using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;

namespace WebCollectorLib
{
    public class WebsiteParser
    {
        public string DescendantTag { get; private set; }
        public string AnchorTag { get; private set; }

        public WebsiteParser()
        {
            DescendantTag = "h2";
            AnchorTag = "a";
        }

        public string BuildLinkPath(string keyword)
        {
            return $"https://www.deraktionaer.de/suchen?page=1&q={keyword}";
        }

        public IEnumerable<string> FindLinks(string htmlContent)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            var linkNodes = htmlDoc.DocumentNode.Descendants(DescendantTag)
                .SelectMany(node => node.Descendants(AnchorTag));

            foreach (var linkNode in linkNodes)
            {
                string link = linkNode.GetAttributeValue("href", "");
                yield return link;
            }
        }

        public IEnumerable<string> FindParagraphs(string htmlContent)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            var paragraphNodes = htmlDoc.DocumentNode.Descendants("p");

            foreach (var paragraphNode in paragraphNodes)
            {
                string paragraph = paragraphNode.InnerText.Trim();
                if (!string.IsNullOrWhiteSpace(paragraph))
                {
                    yield return paragraph;
                }
            }
        }
    }
}