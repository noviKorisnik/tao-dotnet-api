using System.Collections.Generic;

namespace TaoApi.Models
{
    public class Tao
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}