using Microsoft.EntityFrameworkCore;
using TaoApi.Models;

namespace TaoApi
{
    public class TaoContext : DbContext
    {
        public TaoContext(DbContextOptions<TaoContext> options) : base(options) { }

        public DbSet<Tao> Taos { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }

        private static object locker = new object();
        private static bool bootstrapped = false;
        public void BootstrapTaoDb()
        {
            lock (locker)
            {
                if (!bootstrapped)
                {                   
                    Tao tao = TaoParser.GrabTao();

                    Taos.Add(tao);

                    SaveChanges();

                    bootstrapped = true;
                }
            }
        }
    }
}