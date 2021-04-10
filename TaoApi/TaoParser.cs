using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using TaoApi.Models;

namespace TaoApi
{
    public class TaoParser
    {
        private static readonly string taoPath = @"https://www.mit.edu/~xela/tao.html";

        private Tao tao;
        private Book book;
        private Chapter chapter;
        private Paragraph paragraph;
        private TaoParsingPhase phase;
        public static Tao GrabTao()
        {
            TaoParser parser = new TaoParser()
            {
                tao = new Tao { Books = new List<Book>(), },
            };

            HtmlWeb web = new HtmlWeb();

            HtmlDocument htmlDoc = web.Load(taoPath);

            htmlDoc
            .DocumentNode
            .SelectSingleNode("//body")
            .ChildNodes
            .ToList()
            .ForEach(node => parser.doSomethingWithNode(node));

            return parser.tao;
        }
        private void doSomethingWithNode(HtmlNode node)
        {
            switch (phase)
            {
                case TaoParsingPhase.TaoDefinition:
                    doTaoDefinition(node);
                    break;
                case TaoParsingPhase.BookDefinition:
                    doBookDefinition(node);
                    break;
                case TaoParsingPhase.ChapterDefinition:
                    doChapterDefinition(node);
                    break;
            }
        }
        private void doTaoDefinition(HtmlNode node)
        {
            switch (node.Name)
            {
                case "h1":
                    tao.Title = node.InnerText.Clean();
                    break;
                case "h4":
                    tao.Author = node.InnerText.Clean();
                    break;
                case "h3":
                    doBookDefinition(node, true);
                    break;
            }
        }
        private void doBookDefinition(HtmlNode node, bool create = false)
        {
            if (create)
            {
                phase = TaoParsingPhase.BookDefinition;
                book = new Book { Chapters = new List<Chapter>(), };
                tao.Books.Add(book);
            }
            switch (node.Name)
            {
                case "h3":
                    book.Code = node.InnerText.Clean();
                    break;
                case "h2":
                    book.Title = node.InnerText.Clean();
                    break;
                case "h5":
                    book.Quoted = node.InnerText.Clean();
                    break;
                case "p":
                    book.Quote = node.InnerText.Clean();
                    break;
                case "h4":
                    doChapterDefinition(node, true);
                    break;
            }
        }
        private void doChapterDefinition(HtmlNode node, bool create = false)
        {
            if (create)
            {
                phase = TaoParsingPhase.ChapterDefinition;
                chapter = new Chapter { Paragraphs = new List<Paragraph>(), };
                book.Chapters.Add(chapter);
            }
            switch (node.Name)
            {
                case "h4":
                    if (create)
                    {
                        chapter.Code = node.InnerText.Clean();
                    }
                    else
                    {
                        doChapterDefinition(node, true);
                    }
                    break;
                case "p":
                case "blockquote":
                    paragraph = new Paragraph
                    {
                        Text = node.InnerText.Clean(node.Name == "blockquote"),
                        IsBlockquote = node.Name == "blockquote",
                    };
                    chapter.Paragraphs.Add(paragraph);
                    break;
                case "h3":
                    doBookDefinition(node, true);
                    break;
            }
        }
    }
    public enum TaoParsingPhase
    {
        TaoDefinition,
        BookDefinition,
        ChapterDefinition,
    }
    public static class StringExtensions
    {
        public static string Clean(this string text, bool preserveBreaks = false)
        {
            try
            {
                return string.Join(
                    preserveBreaks ? "\r\n" : " ",
                    text.Split('\n')
                    .Select(line => line.Trim())
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                );
            }
            catch
            {
                return text;
            }
        }
    }
}