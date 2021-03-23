using System.Collections.Generic;

namespace TaoApi.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Paragraph> Paragraphs { get; set; }
    }
}