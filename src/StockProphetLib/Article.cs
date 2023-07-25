using System;
using System.Collections;
using System.Collections.Generic;

namespace StockProphetLib
{
    public class Article
    {
        private static int counter = 0; 
        public int ID { get; private set; }
        public string Link { get; set; }
        public List<string> Paragraphs { get; set; }
        public float Sentiment { get; set; }

        public Article() 
        {
            ID          = counter++;
            Link        = "";
            Paragraphs  = new List<string>();
            Sentiment   = 0.0f;
        }
    }
}