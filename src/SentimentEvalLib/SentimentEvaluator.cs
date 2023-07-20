using System;

using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;


namespace SentimentEvalLib
{
    public interface ISentimentTrain
    {
        void LoadData(string path);
        void CreateModel();
        void Fit();
        void Test();
        void SaveModel(string path);
    }


    public interface ISentiment
    {
        void LoadModel(string path);
        SentimentPrediction Evaluate(SentimentData data);
    }


    public class SentimentEvaluator : ISentimentTrain, ISentiment
    {
        private MLContext MlContext;
        private TrainTestData SplitDataView;
        private ITransformer Model;

        void ISentimentTrain.LoadData(string path) {}
        void ISentimentTrain.CreateModel() {}
        void ISentimentTrain.Fit() {}
        void ISentimentTrain.Test() {}
        void ISentimentTrain.SaveModel(string path) {}       
        
        void ISentiment.LoadModel(string path) {}
        SentimentPrediction ISentiment.Evaluate(SentimentData data) {
            return new SentimentPrediction { Probability = -1.0f };
        }
    }
}