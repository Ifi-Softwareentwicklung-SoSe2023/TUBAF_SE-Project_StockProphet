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
        private List<Article> Articles;
        private List<IArticleHandler> Handlers;

        public StockProphet(string ModelPath) 
        {
            Articles = new List<Article>();
            Handlers = new List<IArticleHandler>();

            Handlers.Add(new Collector());
            Handlers.Add(new PreProcessor());
            Handlers.Add(new Evaluator(ModelPath));
        }

        public StockProphet() : this("../../model/model")
        {}
        
        public float Prophesy(string KeyWord) 
        { 
            // initiation
            LinkCollector linkCollector = new LinkCollector();
            string[] links = linkCollector.FindLinks(KeyWord);  
            
            CreateArticles(links);

            Task[] tasks = StartTasks();
            Terminal terminal = new Terminal(Articles);

            // main processing
            StatusLoop(tasks, terminal);

            // result
            float totalSentiment = SumSentiment();
            terminal.PrintResult(totalSentiment);

            return totalSentiment;
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

        private Task[] StartTasks() 
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

            return tasks;
        }

        private void StatusLoop(Task[] Tasks, Terminal Terminal)
        {
            Task t = Task.WhenAll(Tasks);
            try
            {
                while(t.Status == TaskStatus.WaitingForActivation)
                {
                    Terminal.PrintStatus();
                    Thread.Sleep(100);
                }
            }
            catch {}
            
            if (t.Status == TaskStatus.Faulted)
                Console.WriteLine("Not all article tasks have completed.");
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