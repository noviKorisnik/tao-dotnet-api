using Microsoft.Extensions.Logging;
using TaoApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TaoApi
{
    public class TaoRepository
    {
        private readonly ILogger<TaoRepository> _logger;
        private readonly TaoContext _context;
        public TaoRepository(ILogger<TaoRepository> logger, TaoContext context)
        {
            _logger = logger;
            _context = context;
        }
        public Tao GetTao()
        {
            return _context.Taos.Include("Books").Single();
        }
        public Book GetBook(string code)
        {
            return _context.Books.Include("Tao").Include("Chapters").Where(book => book.Code.Contains(code)).Single();
        }
        public Chapter GetChapter(string code)
        {
            return _context.Chapters.Include("Book.Tao").Include("Paragraphs").Where(chapter => chapter.Code.Equals(code)).Single();
        }
    }
}