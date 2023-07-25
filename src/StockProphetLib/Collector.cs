using System;
using WebCollectorLib;

namespace StockProphetLib
{
    public class Collector : IArticleHandler
    {
        private ParagraphCollector paragraphCollector;

        public Collector()
        {
            paragraphCollector = new ParagraphCollector();
        }

        void IArticleHandler.Run(object obj) 
        {
            Article article = (Article)obj;
            article.Paragraphs = paragraphCollector
                .ExtractParagraphsFromLinks(article.Link);
        }
    }
}