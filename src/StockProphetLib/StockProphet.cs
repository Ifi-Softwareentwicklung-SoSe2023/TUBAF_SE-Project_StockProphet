using System;
using WebCollectorLib;

namespace StockProphetLib
{
    class StockProphet
    {
        private Terminal Terminal;
        private List<string> Links;
        private LinkCollector LinkCollector;
        private List<IArticleHandler> Handlers;

        public StockProphet() {}
        
        public float Prophesy(string keyWord) {}

        private void StartTasks() {}
    }
}