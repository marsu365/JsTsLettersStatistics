using JsTsLettersStatistics;
using JsTsLettersStatistics.GitHub;
using JsTsLettersStatistics.Statistics;
using System.IO.Compression;

Console.Clear();

var repoOwner = "lodash";
var projectName = "lodash";
var fileExtensions = new string[] { "js", "ts" };

var repoBytes = await RepoClient.GetRepositoryZip(repoOwner, projectName);

var repoPath = Path.Combine(Directory.GetCurrentDirectory(), "tempRepo");
if (Directory.Exists(repoPath))
    Directory.Delete(repoPath, true);

ZipFile.ExtractToDirectory(new MemoryStream(repoBytes), repoPath);

var lettersOccuranceStatistics = new Dictionary<string, int>();
LettersStatisticsCalculator.CalculateLettersStatistics(ref lettersOccuranceStatistics, repoPath, fileExtensions);
var orderdedStatistics = lettersOccuranceStatistics.OrderByDescending(x => x.Value).ToDictionary();

Printer.Displaytatistics(orderdedStatistics, repoOwner, projectName, fileExtensions);

if (Directory.Exists(repoPath))
    Directory.Delete(repoPath, true);