using System.Collections.Generic;

namespace TaoApi.DataTransferObjects
{
    public class ChapterDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Code { get; set; }
        public ICollection<ParagraphDto> Paragraphs { get; set; }
    }
}