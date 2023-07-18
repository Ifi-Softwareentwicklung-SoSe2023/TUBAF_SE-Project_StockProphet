using System;

namespace StockProphetLib
{
    class Article
    {
        public int ID { get; private set; }
        public string Link { get; private set; }
        public string Title { get; private set; }
        public string Content { get; set; }

        public Article() {}
    }
}