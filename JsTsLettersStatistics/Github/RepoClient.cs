using Octokit;

namespace JsTsLettersStatistics.GitHub
{
    public static class RepoClient
    {
        public async static ValueTask<byte[]> GetRepositoryZip(string owner, string repo)
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
