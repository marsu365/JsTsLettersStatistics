using JsTsLettersStatistics;

Console.Clear();

var repoOwner = "lodash";
var projectName = "lodash";
var allowedFileExtensions = new string[] { "js", "ts" };

var path = await RepoService.PrepareDirectory(repoOwner, projectName);

var statistics = LettersStatisticsCalculator.GetLettersOccuranceStatisticFromDirectory(path, allowedFileExtensions);

OutputViewer.DisplayStatistics(statistics, repoOwner, projectName, allowedFileExtensions);

if (Directory.Exists(path))
    Directory.Delete(path, true);