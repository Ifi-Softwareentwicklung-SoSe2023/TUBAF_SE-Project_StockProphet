using System;
using WebCollectorLib;

namespace StockProphetLib
{
    class Collector : IArticleHandler
    {
        private RawToContent ContentExtractor;

        public void IArticleHandler.Run(Article article) {}
    }
}