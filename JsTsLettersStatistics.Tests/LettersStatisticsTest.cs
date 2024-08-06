
using JsTsLettersStatistics.Statistics;

namespace JsTsLettersStatistics.Tests
{
    public class LettersStatisticsTest
    {
        [Test]
        public void LettersOccurancesStatisticsTest()
        {
            // Arrange
            var acceptedExtensions = new string[] { "js", "ts" };
            var testFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles", "ExampleLettersStatistics");
            var lettersStatistics = new Dictionary<string, int>();

            // Act
            LettersStatisticsCalculator.CalculateLettersStatistics(ref lettersStatistics, testFolderPath, acceptedExtensions);
            var orderedStatistics = lettersStatistics.OrderByDescending(x => x.Value);

            // Assert
            var expectedResult = new Dictionary<string, int>()
            {
                {"E", 271},
                {"T", 250},
                {"N", 201},
                {"R", 187},
                {"A", 176},
                {"O", 165},
                {"S", 150},
                {"C", 129},
                {"I", 121},
                {"U", 93},
                {"F", 88},
                {"P", 70},
                {"D", 70},
                {"L", 69},
                {"M", 56},
                {"H", 50},
                {"B", 43},
                {"G", 39},
                {"W", 24},
                {"Y", 22},
                {"V", 18},
                {"J", 16},
                {"X", 15},
                {"K", 11},
                {"Q", 2 },
            };

            Assert.That(orderedStatistics, Is.EqualTo(expectedResult));
        }
    }
}