using System;
using WebCollectorLib;

namespace StockProphetLib
{
    class Collector : IArticleHandler
    {
        private ParagraphCollector ContentExtractor;

        public void IArticleHandler.Run(Article article) {}
    }
}