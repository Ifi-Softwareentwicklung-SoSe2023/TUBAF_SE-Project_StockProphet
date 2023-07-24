using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;

namespace WebCollectorLib
{
    public class WebsiteParser_1 : IWebsiteParser
    {
        public string DescendantTag { get; private set; }
        public string AnchorTag { get; private set; }

        public WebsiteParser_1()
        {
            DescendantTag = "h2";
            AnchorTag = "a";
        }

        string IWebsiteParser.BuildLinkPath(string keyword)
        {
            return $"https://www.deraktionaer.de/suchen?page=1&q={keyword}";
        }

        IEnumerable<string> IWebsiteParser.FindLinks(string htmlContent)
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

        IEnumerable<string> IWebsiteParser.FindParagraphs(string htmlContent)
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