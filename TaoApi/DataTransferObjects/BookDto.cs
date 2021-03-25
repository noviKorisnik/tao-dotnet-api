using System.Collections.Generic;

namespace TaoApi.DataTransferObjects
{
    public class BookDto
    {
        public int Id { get; set; }
        public int TaoId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Quoted { get; set; }
        public string Quote { get; set; }
        public ICollection<ChapterDto> Chapters { get; set; }
    }
}