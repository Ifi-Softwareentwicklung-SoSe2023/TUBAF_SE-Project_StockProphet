using System;
using System.Collections;
using System.Collections.Generic;

using WebCollectorLib;


namespace StockProphetLib
{
    public class StockProphet
    {
        private Terminal Terminal;
        private List<Article> Articles;
        private List<IArticleHandler> Handlers;

        public StockProphet() {}
        
        public float Prophesy(string keyWord) { return new float(); }

        private void StartTasks() {}
    }
}