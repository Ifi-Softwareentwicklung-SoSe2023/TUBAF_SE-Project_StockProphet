using System;
using SentimentEvalLib;

namespace StockProphetLib
{
    class Evaluator : IArticleHandler
    {
        private ISentiment SentimentEval;

        void IArticleHandler.Run(Article article) {}

        private float EvaluateParagraph(string paragraph) { return new float(); }
    }
}