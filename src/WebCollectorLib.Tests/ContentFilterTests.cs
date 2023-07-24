using System;
using Xunit;
using WebCollectorLib;

namespace WebCollectorLib.Tests
{
    public class ContentFilterTests
    {
        [Theory]
        [JsonFileData("../../../test_data.json", "RemoveLines")]
        public static void Should_RemoveLines(string input, string expected)
        {
            // Act
            string actual = ContentFilter.RemoveLines(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [JsonFileData("../../../test_data.json", "ReplaceName")]
        public void Should_ReplaceName(string input, string name, string expected)
        {
            // Act
            string actual = ContentFilter.ReplaceName(input, name);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
