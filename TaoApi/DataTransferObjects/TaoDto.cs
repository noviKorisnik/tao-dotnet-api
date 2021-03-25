using System.Collections.Generic;

namespace TaoApi.DataTransferObjects
{
    public class TaoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public ICollection<BookDto> Books { get; set; }
    }
}