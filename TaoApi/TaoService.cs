using Microsoft.Extensions.Logging;
using TaoApi.Models;
using TaoApi.DataTransferObjects;
using AutoMapper;

namespace TaoApi
{
    public class TaoService
    {
        private readonly ILogger<TaoService> _logger;
        private readonly TaoRepository _repository;
        private readonly IMapper _mapper;
        public TaoService(ILogger<TaoService> logger, TaoRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        public TaoDto GetTao()
        {
            return _mapper.Map<Tao, TaoDto>(_repository.GetTao());
        }
        public BookDto GetBook(string code)
        {
            return _mapper.Map<Book, BookDto>(_repository.GetBook(code));
        }
        public ChapterDto GetChapter(string code)
        {
            return _mapper.Map<Chapter, ChapterDto>(_repository.GetChapter(code));
        }
    }
}