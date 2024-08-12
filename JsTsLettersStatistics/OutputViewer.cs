namespace JsTsLettersStatistics
{
    public static class OutputViewer
    {
        public static void DisplayStatistics(Dictionary<string, int> lettersStatistics, string repositoryOwner, string projectName, string[] fileExtensions)
        {
            Console.WriteLine();
            Console.WriteLine($"###### Letter occurance statistics in {repositoryOwner}/{projectName} repository for {string.Join(", ", fileExtensions)} files ######");
            Console.WriteLine();

            foreach (var letterStatistic in lettersStatistics)
            {
                Console.WriteLine(String.Format("|{0,3}|{1,12}|", letterStatistic.Key, letterStatistic.Value));
            }
        }
    }
}