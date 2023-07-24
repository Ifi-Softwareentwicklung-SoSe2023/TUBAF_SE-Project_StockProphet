using System;
using WebCollectorLib;

namespace StockProphetLib
{
    public class Collector : IArticleHandler
    {
        private ParagraphCollector ContentExtractor;

        void IArticleHandler.Run(Article article) {}
    }
}