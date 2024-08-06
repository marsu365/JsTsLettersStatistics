namespace JsTsLettersStatistics.GitHubClient
{
    public static class Actions
    {
        public const string GetContentsZip = "/repos/{owner}/{repo}/zipball/{ref}";
        public const string GetContents = "/repos/{owner}/{repo}/contents/{path}";
    }
}
