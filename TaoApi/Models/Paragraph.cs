namespace TaoApi.Models
{
    public class Paragraph
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public virtual Chapter Chapter { get; set; }
        public string Text { get; set; }
        public bool IsBlockquote { get; set; }
    }
}