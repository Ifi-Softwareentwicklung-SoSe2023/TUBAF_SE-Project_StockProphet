using System;
using System.Collections.Generic;


namespace StockProphetLib
{
    class Terminal
    {
        private List<Article> Articles;

        public Terminal(List<Article> Articles) 
        {
            this.Articles = Articles;
        }

        public void PrintStatus() 
        {
            Console.Clear();

            Console.WriteLine("Progress on found articles: ");
            foreach (var article in Articles)
            {
                string str = $"[Article {article.ID}]".PadRight(15);
                str += $"Paragraphs: {article.Paragraphs.Count}".PadRight(18);
                str += "Sentiment: ";
                Console.Write(str);
                SetColorByValue(article.Sentiment);
                Console.WriteLine(article.Sentiment.ToString("0.00"));
                ResetColor();
            }
        }

        public void PrintResult(float TotalSentiment)
        {
            Console.Clear();

            Console.WriteLine("Found articles: ");
            foreach (var article in Articles)
            {
                // SetColorByValue(article.Sentiment);
                // Console.WriteLine("Article link: " + article.Link);

                string str = $"[Article {article.ID}]".PadRight(15);
                str += $"Paragraphs: {article.Paragraphs.Count}".PadRight(18);
                str += "Sentiment: ";
                Console.Write(str);
                SetColorByValue(article.Sentiment);
                Console.Write(article.Sentiment.ToString("0.00").PadRight(9));
                ResetColor();
                Console.WriteLine($"Link: {article.Link}");
            }
            Console.WriteLine();

            Console.Write("Total sentiment: ");
            SetColorByValue(TotalSentiment);
            Console.WriteLine(TotalSentiment);
            ResetColor();
            Console.WriteLine();
        }
    
        private void SetColorByValue(float val)
        {
            Console.ForegroundColor = val switch {
                > 0.25f => ConsoleColor.Green,
                < -0.25f => ConsoleColor.Red,
                _ => ConsoleColor.Yellow
            };
        }

        private void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}