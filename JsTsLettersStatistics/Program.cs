using JsTsLettersStatistics;
using System.Diagnostics;

var stopWatch = Stopwatch.StartNew();

Console.Clear();

var repoOwner = "lodash";
var projectName = "lodash";
var allowedFileExtensions = new string[] { "js", "ts" };

var path = await RepoService.PrepareDirectory(repoOwner, projectName);

var statistics = LettersStatisticsCalculator.GetLettersOccuranceStatisticFromDirectory(path, allowedFileExtensions);

OutputViewer.DisplayStatistics(statistics, repoOwner, projectName, allowedFileExtensions);

if (Directory.Exists(path))
    Directory.Delete(path, true);

Console.WriteLine();
Console.WriteLine($"###### Results fetched in {stopWatch.ElapsedMilliseconds} miliseconds ######");
Console.ReadLine();