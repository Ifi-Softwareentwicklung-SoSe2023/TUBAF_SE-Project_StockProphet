using System;
using Xunit;
using SentimentEvalLib;

namespace SentimentEvalLib.Tests
{
    public class SentimentEvaluatorTests
    {
        [Theory]
        [InlineData("Things are going well.")]
        [InlineData("It's not looking good.")]
        public void Evaluate_ShouldReturnValidPredictionProbability(string text)
        {
            // Arrange
            ISentiment evaluator = new SentimentEvaluator();
            evaluator.LoadModel("../../../../../model/model");
            SentimentData data = new SentimentData { SentimentText = text };

            // Act
            float actual = evaluator.Evaluate(data).Probability;

            // Assert
            Assert.InRange<float>(actual, 0.0f, 1.0f);
        }

        [Fact]
        public void Evaluate_ShouldThrowOnEmpty()
        {
            // Arrange
            ISentiment evaluator = new SentimentEvaluator();
            evaluator.LoadModel("../../../../../model/model");
            SentimentData data = new SentimentData { SentimentText = "" };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => evaluator.Evaluate(data));
        }
    }
}
