using Markdig;
using System;
using System.IO;

namespace MarkdownSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            try
            {
                string markdown = File.ReadAllText("../../src/MarkdownSample/MarkdownSample1.md");
                string html = Markdown.ToHtml(markdown);
                Console.WriteLine(html);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
    }
}
