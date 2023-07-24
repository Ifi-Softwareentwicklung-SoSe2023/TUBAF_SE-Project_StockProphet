using System;

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
                Console.WriteLine("[Article {0}]    Paragraphs: {1},    Sentiment: {2}",
                    article.ID, article.Paragraphs.Count, article.Sentiment);
            }
        }

        public void PrintResult(float TotalSentiment)
        {
            Console.WriteLine("Found articles: ");
            foreach (var article in Articles)
            {
                Console.ForegroundColor = article.Sentiment switch {
                    > 0.25f => ConsoleColor.Green,
                    < -0.25f => ConsoleColor.Red,
                    _ => ConsoleColor.Yellow
                };

                Console.WriteLine("Article link: " + article.Link);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Total sentiment: ");

            Console.ForegroundColor = TotalSentiment switch {
                > 0.25f => ConsoleColor.Green,
                < -0.25f => ConsoleColor.Red,
                _ => ConsoleColor.Yellow
            };
            Console.WriteLine(TotalSentiment);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}