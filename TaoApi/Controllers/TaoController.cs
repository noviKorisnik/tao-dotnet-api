using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaoApi.DataTransferObjects;

namespace TaoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaoController : ControllerBase
    {
        private readonly ILogger<TaoController> _logger;
        private readonly TaoService _service;

        public TaoController(
            ILogger<TaoController> logger,
            TaoService service
            )
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet()]
        public TaoDto GetTao()
        {
            return _service.GetTao();
        }
        [HttpGet("Book/{code}")]
        public BookDto GetBook(string code)
        {
            return _service.GetBook(code);
        }
        [HttpGet("Chapter/{code}")]
        public ChapterDto Chapters(string code)
        {
            return _service.GetChapter(code);
        }
    }
}
