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

        void IArticleHandler.Run(Article article) 
        {
            article.Paragraphs = paragraphCollector
                .ExtractParagraphsFromLinks(article.Link);
        }
    }
}