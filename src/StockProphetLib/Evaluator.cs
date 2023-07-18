using System;
using SentimentEvalLib;

namespace StockProphetLib
{
    class Evaluator : IArticleHandler
    {
        private ISentiment SentimentEval;

        public void IArticleHandler.Run(Article article) {}

        private float EvaluateParagraph(string paragraph) {}
    }
}