using System;

using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;


namespace SentimentEvalLib
{
    public interface ISentimentTrain
    {
        void TrainModel(string Path);
        void SaveModel(string Path);
    }


    public interface ISentiment
    {
        void LoadModel(string Path);
        SentimentPrediction Evaluate(SentimentData Data);
    }


    public class SentimentEvaluator : ISentimentTrain, ISentiment
    {
        // member variables
        private MLContext       MlContext;
        private DataViewSchema  Schema;
        private ITransformer    Model;
        private PredictionEngine<SentimentData, SentimentPrediction> InferenceFunction;


        // constructor
        public SentimentEvaluator()
        {
            this.MlContext = new MLContext();
        }


        // ISentimentTrain interface
        public void ISentimentTrain.TrainModel(string DataPath) 
        {
            TrainTestData dataset = LoadData(DataPath);
            CreateModel(data.TrainSet);
            Test(data.TestSet);
        }

        private TrainTestData LoadData(string Path) 
        {
            IDataView dataset = MlContext.Data.LoadFromTextFile<SentimentData>(Path, hasHeader: false);
            this.Schema = dataset.Schema;
            return MlContext.Data.TrainTestSplit(dataset, testFraction: 0.2);
        }

        private void CreateModel(IDataView Dataset)
        {
            var estimator = MlContext.Transforms.Text.FeaturizeText(
                    outputColumnName: "Features", 
                    inputColumnName: nameof(SentimentData.SentimentText)
                ).Append(MlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: "Label",
                    featureColumnName: "Features"
                ));

            Console.WriteLine("=============== Training started  ===============");
            this.Model = estimator.Fit(Dataset);
            Console.WriteLine("=============== Training complete ===============");
            Console.WriteLine();
        }

        private void Test(IDataView Dataset) 
        {
            Console.WriteLine("=============== Evaluating model accuracy with Test data ===============");
            
            IDataView predictions = Model.Transform(Dataset);
            CalibratedBinaryClassificationMetrics metrics = 
                MlContext.BinaryClassification.Evaluate(predictions, "Label");

            Console.WriteLine("Model quality metrics evaluation");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
        }

        void ISentimentTrain.SaveModel(string Path) 
        {
            if( !Path.EndsWith(".zip") ) 
            {
                Path += ".zip";
            }

            MlContext.Model.Save(Model, Schema, Path);
        }       
        

        // ISentiment interface
        void ISentiment.LoadModel(string Path) 
        {

        }

        SentimentPrediction ISentiment.Evaluate(SentimentData Data) 
        {
            return new SentimentPrediction { Probability = -1.0f };
        }
    }
}