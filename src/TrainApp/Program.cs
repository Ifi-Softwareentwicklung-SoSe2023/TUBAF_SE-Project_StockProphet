using System;
using SentimentEvalLib;

namespace TrainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ISentimentTrain sentimentEvaluator = new SentimentEvaluator();

            sentimentEvaluator.TrainModel("../../data/dataset.txt");
            sentimentEvaluator.SaveModel("../../model/model.zip");
        }
    }
}
