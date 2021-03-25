using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public object GetTao()
        {
            return _service.GetTao();
        }
        [HttpGet("Book/{code}")]
        public object GetBook(string code)
        {
            return _service.GetBook(code);
        }
        [HttpGet("Chapter/{code}")]
        public object Chapters(string code)
        {
            return _service.GetChapter(code);
        }
    }
}
