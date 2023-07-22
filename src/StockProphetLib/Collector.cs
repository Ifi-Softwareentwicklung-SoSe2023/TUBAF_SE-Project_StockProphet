using System;
using WebCollectorLib;

namespace StockProphetLib
{
    public class Collector : IArticleHandler
    {
        private RawToContent ContentExtractor;

        void IArticleHandler.Run(Article article) {}
    }
}