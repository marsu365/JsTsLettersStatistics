namespace JsTsLettersStatistics
{
    public static class Printer
    {
        public static void Displaytatistics(Dictionary<string, int> lettersStatistics)
        {
            foreach (var letterStatistic in lettersStatistics)
            {
                Console.WriteLine($"{letterStatistic.Key} - {letterStatistic.Value}");
            }
        }
    }
}
