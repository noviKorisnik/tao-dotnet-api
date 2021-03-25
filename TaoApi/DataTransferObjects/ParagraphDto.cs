namespace TaoApi.DataTransferObjects
{
    public class ParagraphDto
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public string Text { get; set; }
        public bool IsBlockquote { get; set; }
    }
}