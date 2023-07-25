using System;
using System.Collections.Generic;

namespace WebCollectorLib
{
    public interface IWebsiteParser
    {
        string BuildLinkPath(string keyword);
        IEnumerable<string> FindLinks(string rawHtml);
        IEnumerable<string> FindParagraphs(string rawHtml);
    }
}