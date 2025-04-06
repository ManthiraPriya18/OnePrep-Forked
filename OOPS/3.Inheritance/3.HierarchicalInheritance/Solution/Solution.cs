using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming._3.Inheritance.HierarchicalInheritance.Solution
{

    /*
     * Here Hiereachial inheritance is acheived by The Content as parent & VideoContent,ArticleContent,PodcastContent
     * 
     */
    class Content
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty ;
        public Content(string Author,string Title)
        {
            this.Author = Author;
            this.Title = Title;
        }
        public void Publish()
        {
            Console.WriteLine($"Publishing: {Title} by {Author}");
        }
    }

    class VideoContent : Content
    {
        public VideoContent(string Author, string Title) : base(Author, Title)
        {
        }

        public void PlayVideo() => Console.WriteLine("Playing video...");
    }

    class ArticleContent : Content
    {
        public ArticleContent(string Author, string Title) : base(Author, Title)
        {
        }
        public void ReadArticle() => Console.WriteLine("Reading article...");
    }

    class PodcastContent : Content
    {
        public PodcastContent(string Author, string Title) : base(Author, Title)
        {
        }
        public void StreamAudio() => Console.WriteLine("Streaming podcast...");
    }

}
