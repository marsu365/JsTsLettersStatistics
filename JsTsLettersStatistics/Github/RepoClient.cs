using Octokit;
using System.Net;

namespace JsTsLettersStatistics.GitHub
{
    public static class RepoClient
    {
        public async static ValueTask<Stream> GetRepositoryZip(string owner, string repo)
        {
            var client = new GitHubClient(new ProductHeaderValue(repo));

            try
            {
                var releases = await client.Repository.Release.GetAll(owner, repo);

                if (releases is null || releases.Count == 0)
                {
                    Console.WriteLine("No releases found for given repository");
                    return Stream.Null;
                }

                var latest = releases[0];

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("user-agent", nameof(HttpRequestHeader.UserAgent));
                var zipStream = await httpClient.GetStreamAsync(latest.ZipballUrl);

                return zipStream;
            }
            catch (Octokit.NotFoundException)
            {
                Console.WriteLine($"Repository not found!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured while fetching repository. Message: {ex.Message}");
            }

            return Stream.Null;
        }
    }
}
