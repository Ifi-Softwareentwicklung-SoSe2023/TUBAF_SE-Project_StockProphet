using System;
using Xunit;
using StockProphetLib;

namespace StockProphetLib.Tests
{
    public class StockProphetTests
    {
        [Theory]
        [InlineData("LeCompany")]
        [InlineData("StonksCo.")]
        public void Prophesy_ShouldReturnFloatInRange0To1(string keyword)
        {
            // Arrange
            StockProphet prophet = new StockProphet();
            
            // Act
            float actual = prophet.Prophesy(keyword);

            // Assert
            Assert.InRange<float>(actual, -1.0f, 1.0f);
        }


        [Fact]
        public void Prophesy_ShouldThrowOnEmpty()
        {
            // Arrange
            StockProphet prophet = new StockProphet();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => prophet.Prophesy(""));
        }


        [Theory]
        [InlineData("That Coorperation")]
        [InlineData(" WhiteSpaceCo")]
        public void Prophesy_ShouldThrowOnSpaces(string keyword)
        {
            // Arrange
            StockProphet prophet = new StockProphet();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => prophet.Prophesy(keyword));
        }
    }
}
