using Markdig;
using System;
using System.IO;

namespace MarkdownSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunAdvanced();
        }

        public static void Run()
        {
            try
            {
                string filename = Path.Combine(Directory.GetCurrentDirectory(), "MarkdownSample1.md");
                string markdown = File.ReadAllText(filename);
                string html = Markdown.ToHtml(markdown);
                Console.WriteLine(html);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void RunAdvanced()
        {
            try
            {
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                string filename = Path.Combine(Directory.GetCurrentDirectory(), "MarkdownSample1.md");
                string markdown = File.ReadAllText(filename);
                string html = Markdown.ToHtml(markdown, pipeline);
                Console.WriteLine(html);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
