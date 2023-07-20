using System;

using Microsoft.ML;
using Microsoft.ML.Data;
using SentimentAnalysis;
using static Microsoft.ML.DataOperationsCatalog;


namespace SentimentEvalLib
{
    interface ISentimentTrain
    {
        void LoadData(string path);
        void CreateModel();
        void Fit();
        void Test();
        void SaveModel(string path);
    }


    interface ISentiment
    {
        void LoadModel(string path);
        SentimentPrediction Evaluate(SentimentData data);
    }


    class SentimentEvaluator : ISentimentTrain, ISentiment
    {
        private MLContext MlContext;
        private TrainTestData SplitDataView;
        private ITransformer Model;

        public void ISentimentTrain.LoadData(string path) {}
        public void ISentimentTrain.CreateModel() {}
        public void ISentimentTrain.Fit() {}
        public void ISentimentTrain.Test() {}
        public void ISentimentTrain.SaveModel(string path) {}     

        public void ISentiment.LoadModel(string path) {}
        public SentimentPrediction ISentiment.Evaluate(SentimentData data) {}
    }
}