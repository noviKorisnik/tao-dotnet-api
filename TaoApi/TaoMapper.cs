using AutoMapper;
using TaoApi.Models;
using TaoApi.DataTransferObjects;

namespace TaoApi
{
    public class TaoMapper : Profile
    {
        public TaoMapper()
        {
            CreateMap<Tao, TaoDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Chapter, ChapterDto>();
            CreateMap<Paragraph, ParagraphDto>();
        }
    }
}