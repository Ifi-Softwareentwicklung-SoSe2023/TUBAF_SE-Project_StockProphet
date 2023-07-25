using System;
using System.Collections;
using System.Collections.Generic;

namespace StockProphetLib
{
    public class Article
    {
        private static int counter = 0; 
        public int ID { get; private set; }
        public string Keyword { get; private set; }
        public string Link { get; set; }
        public List<string> Paragraphs { get; set; }
        public float Sentiment { get; set; }

        public Article(string keyword) 
        {
            ID          = counter++;
            Keyword     = keyword;
            Link        = "";
            Paragraphs  = new List<string>();
            Sentiment   = 0.0f;
        }
    }
}