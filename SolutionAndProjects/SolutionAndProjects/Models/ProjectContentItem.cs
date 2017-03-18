using System.IO;

namespace SolutionAndProjects.Models
{
    public class ProjectContentItem
    {
        public ProjectContentItem(string include, FileInfo fileInfo)
        {
            FileInfo = fileInfo;
            Include = include;
        }

        public string Include { get; }

        public FileInfo FileInfo { get; }
    }
}