using System;
using Xunit;
using WebCollectorLib;

namespace WebCollectorLib.Tests
{
    public class ContentFilterTests
    {
        [Theory]
        [JsonFileData("../../../test_data.json", "RemoveAuthors")]
        public static void Should_RemoveAuthors(string input, string expected)
        {
            // Act
            string actual = ContentFilter.RemoveAuthors(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [JsonFileData("../../../test_data.json", "ChangeName")]
        public void Should_ChangeName(string input, string name, string expected)
        {
            // Act
            string actual = ContentFilter.ChangeName(input, name);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [JsonFileData("../../../test_data.json", "RemoveEmojis")]
        public void Should_RemoveEmojis(string input, string expected)
        {
            // Act
            string actual = ContentFilter.RemoveEmojis(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
