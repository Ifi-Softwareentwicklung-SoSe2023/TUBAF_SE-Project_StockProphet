using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using WebCollectorLib;


namespace StockProphetLib
{
    public class StockProphet
    {
        private Terminal Terminal;
        private List<Article> Articles;
        private List<IArticleHandler> Handlers;

        public StockProphet() : this("../../model/model")
        {}

        public StockProphet(string modelPath) 
        {
            Handlers.Add(new Collector());
            Handlers.Add(new PreProcessor());
            Handlers.Add(new Evaluator(modelPath));
        }
        
        public float Prophesy(string KeyWord) 
        { 
            LinkCollector linkCollector = new LinkCollector();
            string[] links = linkCollector.FindLinks(KeyWord);  
         
            CreateArticles(links);
            RunTasks();         
            return SumSentiment();
        }

        private void CreateArticles(string[] Links) 
        {
            foreach (var ln in Links)
            {
                Article article = new Article();
                article.Link = ln;
                Articles.Add(article);
            }
        }

        private void RunTasks() 
        {
            // prepare multicast delegate
            Action<object> chain = new Action<object>((object obj) => {});
            foreach (var handler in Handlers) {
                chain += handler.Run;
            }

            Task[] tasks = new Task[Articles.Count];

            // start tasks
            int i = 0;
            foreach (var article in Articles)
            {
                tasks[i] = new Task(chain, (object)article);
                tasks[i++].Start();
            }

            // wait for tasks to finish
            try 
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Aggregation failed: {0}", e.Message);
            }
        }

        private float SumSentiment() 
        {
            float sum = 0;
            int count = 0;
            foreach (var article in Articles)
            {
                sum += article.Sentiment;
                count++;
            }

            return sum / count;
        }
    }
}