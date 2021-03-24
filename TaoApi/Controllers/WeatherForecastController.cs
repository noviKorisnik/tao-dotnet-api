using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TaoContext _context;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            TaoContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("taos")]
        public object Taos()
        {
            return _context.Taos;
        }
        [HttpGet("books")]
        public object Books()
        {
            return _context.Books;
        }
        [HttpGet("chapters")]
        public object Chapters()
        {
            return _context.Chapters;
        }
        [HttpGet("paragraphs")]
        public object Paragraphs()
        {
            return _context.Paragraphs;
        }
    }
}
