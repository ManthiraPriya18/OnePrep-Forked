using ObjectOrientedProgramming._3.Inheritance.HierarchicalInheritance.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._3.Inheritance.HierarchicalInheritance.Problem
{
    /*
     * Here we are having three classes VideoContent,ArticleContent,PodcastContent, all these classes having few implementation as common
     * This is actually leading to duplicate code, we can solve this using Hierarchical Inheritance
     */
    class VideoContent 
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public VideoContent(string Author, string Title) 
        {
            this.Author = Author;
            this.Title = Title;
        }
        public void Publish()
        {
            Console.WriteLine($"Publishing: {Title} by {Author}");
        }
        public void PlayVideo() => Console.WriteLine("Playing video...");
    }

    class ArticleContent 
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public ArticleContent(string Author, string Title) 
        {
            this.Author = Author;
            this.Title = Title;
        }
        public void Publish()
        {
            Console.WriteLine($"Publishing: {Title} by {Author}");
        }
        public void ReadArticle() => Console.WriteLine("Reading article...");
    }

    class PodcastContent 
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public PodcastContent(string Author, string Title) 
        {
            this.Author = Author;
            this.Title = Title;
        }
        public void Publish()
        {
            Console.WriteLine($"Publishing: {Title} by {Author}");
        }
        public void StreamAudio() => Console.WriteLine("Streaming podcast...");
    }
}
