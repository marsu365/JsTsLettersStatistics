using JsTsLettersStatistics;
using JsTsLettersStatistics.GitHub;
using JsTsLettersStatistics.Statistics;
using System.IO.Compression;

Console.Clear();

Console.WriteLine("Please provide repo owner name");
string repoOwner = Console.ReadLine();

Console.WriteLine("Please provide project name");
string projectName = Console.ReadLine();

var repoStream = await RepoClient.GetRepositoryZip(repoOwner, projectName);

var repoPath = Path.Combine(Directory.GetCurrentDirectory(), "tempRepo");
if (Directory.Exists(repoPath))
    Directory.Delete(repoPath, true);

ZipFile.ExtractToDirectory(repoStream, repoPath);

var lettersOccuranceStatistics = new Dictionary<string, int>();
LettersStatisticsCalculator.CalculateLettersStatistics(ref lettersOccuranceStatistics, repoPath, new string[] { "js", "ts" });
var orderdedStatistics = lettersOccuranceStatistics.OrderByDescending(x => x.Value).ToDictionary();

Printer.Displaytatistics(orderdedStatistics);

if (Directory.Exists(repoPath))
    Directory.Delete(repoPath, true);