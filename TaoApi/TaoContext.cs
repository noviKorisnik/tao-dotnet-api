using Microsoft.EntityFrameworkCore;
using TaoApi.Models;
using System.IO;
using System.Text.Json;

namespace TaoApi
{
    public class TaoContext : DbContext
    {
        public TaoContext(DbContextOptions<TaoContext> options) : base(options) { }

        public DbSet<Tao> Taos { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }

        private static readonly string filename = "Tao.json";
        private static object locker = new object();
        private static bool bootstrapped = false;
        public void BootstrapTaoDb()
        {
            lock (locker)
            {
                if (!bootstrapped)
                {                   
                    string filePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        filename
                    );
                    string json = File.ReadAllText(filePath);
                    Tao tao = JsonSerializer.Deserialize<Tao>(json);

                    Taos.Add(tao);

                    SaveChanges();

                    bootstrapped = true;
                }
            }
        }
    }
}