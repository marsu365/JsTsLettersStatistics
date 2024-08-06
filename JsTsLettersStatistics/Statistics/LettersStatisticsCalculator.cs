using System.Text;

namespace JsTsLettersStatistics.Statistics
{
    public static class LettersStatisticsCalculator
    {
        public static void CalculateLettersStatistics(ref Dictionary<string, int> statistics, string path, string[]? acceptedExtensions)
        {
            if (File.Exists(path))
            {
                if (acceptedExtensions is null)
                {
                    GetStatisticsFromFile(ref statistics, path);
                    return;
                }

                var fileExtension = Path.GetExtension(path)?.Replace(".", "");
                if (!acceptedExtensions.Contains(fileExtension?.Replace(".", "")))
                    return;

                GetStatisticsFromFile(ref statistics, path);
                return;
            }

            if (Directory.Exists(path))
            {
                foreach (var filePath in Directory.GetFiles(path))
                {
                    CalculateLettersStatistics(ref statistics, filePath, acceptedExtensions);
                }

                foreach (var directoryPath in Directory.GetDirectories(path))
                {
                    CalculateLettersStatistics(ref statistics, directoryPath, acceptedExtensions);
                }
            }
        }

        private static void GetStatisticsFromFile(ref Dictionary<string, int> statistics, string path)
        {
            Console.WriteLine("file");
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
            {
                String line;
                while (!streamReader.EndOfStream)
                {
                    try
                    {
                        line = streamReader.ReadLine();

                        if (line is null)
                            continue;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (!((line[i] >= 65
                                && line[i] <= 90)
                                || (line[i] >= 97
                                && line[i] <= 122)))
                                continue;

                            var charValue = line[i].ToString().ToUpper();

                            if (statistics.TryGetValue(charValue, out int occurances))
                            {
                                statistics[charValue] = ++occurances;
                                continue;
                            }

                            statistics[charValue] = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception occured while reading file from path {path}. Message: {ex.Message}");
                    }
                }
            }
        }
    }
}
