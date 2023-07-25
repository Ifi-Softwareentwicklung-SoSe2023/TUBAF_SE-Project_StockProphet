using System;
using SentimentEvalLib;

namespace StockProphetLib
{
    class Evaluator : IArticleHandler
    {
        private ISentiment sentimentEvaluator;

        public Evaluator(string modelPath)
        {
            sentimentEvaluator = new SentimentEvaluator();
            sentimentEvaluator.LoadModel(modelPath);
        }

        void IArticleHandler.Run(object obj) 
        {
            Article article = (Article)obj;

            float sum = 0.0f;
            int counter = 0;
            foreach (var paragraph in article.Paragraphs)
            {
                sum += EvaluateParagraph(paragraph);
                counter++;
                article.Sentiment = sum / counter;
            }
        }

        private float EvaluateParagraph(string paragraph) 
        { 
            SentimentData sample = new SentimentData { SentimentText = paragraph };
            
            SentimentPrediction prediction = sentimentEvaluator.Evaluate(sample);

            float sentiment = prediction.Prediction ? 1.0f : -1.0f;
            sentiment *= prediction.Probability;

            return sentiment;
        }
    }
}