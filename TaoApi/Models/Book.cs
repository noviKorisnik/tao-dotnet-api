using System.Collections.Generic;

namespace TaoApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int TaoId { get; set; }
        public virtual Tao Tao { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Quoted { get; set; }
        public string Quote { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}