using Octokit;
using System.IO.Compression;

namespace JsTsLettersStatistics
{
    public static class RepoService
    {
        public static async ValueTask<string> PrepareDirectory(string repoOwner, string projectName)
        {
            var repoBytes = await GetRepositoryZip(repoOwner, projectName);

            var repoPath = Path.Combine(Directory.GetCurrentDirectory(), "tempRepo");

            if (Directory.Exists(repoPath))
                Directory.Delete(repoPath, true);

            ZipFile.ExtractToDirectory(new MemoryStream(repoBytes), repoPath);
            return repoPath;
        }

        private async static ValueTask<byte[]> GetRepositoryZip(string owner, string repo)
        {
            var client = new GitHubClient(new ProductHeaderValue(repo));

            try
            {
                var zipBytes = await client.Repository.Content.GetArchive(owner, repo, ArchiveFormat.Zipball);
                return zipBytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured while fetching repository. Message: {ex.Message}");
            }

            return Array.Empty<byte>();
        }
    }
}
