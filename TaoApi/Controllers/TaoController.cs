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
        public ActionResult<TaoDto> GetTao()
        {
            try
            {
                return _service.GetTao();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("Book/{code}")]
        public ActionResult<BookDto> GetBook(string code)
        {
            try
            {
                return _service.GetBook(code);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("Chapter/{code}")]
        public ActionResult<ChapterDto> Chapters(string code)
        {
            try
            {
                return _service.GetChapter(code);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
