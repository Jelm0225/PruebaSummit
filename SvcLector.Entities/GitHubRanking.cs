using System;

namespace SvcLector.Entities
{
    public class GitHubRanking
    {
        public int Rank { get; set; }
        public string Item { get; set; }
        public string RepoName { get; set; }
        public string Stars { get; set; }
        public string Forks { get; set; }
        public string Language { get; set; }
        public string RepoUrl { get; set; }
        public string UserName { get; set; }
        public string Issues { get; set; }
        public string LastCommit { get; set; }
        public string Description { get; set; }

    }
}
