using Microsoft.EntityFrameworkCore;
using TaoApi.Models;
using System.IO;
using System.Text.Json;

namespace TaoApi
{
    public class TaoContext : DbContext
    {
        private static object locker = new object();
        private static bool bootstrapped = false;
        public bool IsBootstrapped()
        {
            return bootstrapped;
        }
        public TaoContext(DbContextOptions<TaoContext> options) : base(options)
        {
            lock (locker)
            {
                if (!bootstrapped)
                {
                    this.BootstrapTaoDb();
                    bootstrapped = true;
                    //hm, this first call of context has the whole tree
                    //and retruns it, well, let we throw an exception
                    //it is only once
                    //and yes, it probably can be avoided with safer bootstrap
                    throw new System.Exception();
                }
            }
        }

        public DbSet<Tao> Taos { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
    }
    public static class Extensions
    {
        private static readonly string filename = "Tao.json";
        public static void BootstrapTaoDb(this TaoContext context)
        {
            if (!context.IsBootstrapped())
            {
                string filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    filename
                );
                string json = File.ReadAllText(filePath);
                Tao tao = JsonSerializer.Deserialize<Tao>(json);

                context.Taos.Add(tao);

                context.SaveChanges();
            }
        }
    }

}