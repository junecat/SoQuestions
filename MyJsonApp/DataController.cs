using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace MyJsonApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JFileController : ControllerBase
    {
        private readonly ILogger<JFileController> _logger;

        public JFileController(ILogger<JFileController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Возвращает содержимое статического JSON файла
        /// </summary>
        [HttpGet(Name = "GetData")]
        public IActionResult Get()
        {
            try
            {
                // Путь к файлу относительно текущего каталога
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "src/source.json");

                if (!System.IO.File.Exists(filePath))
                    return NotFound("Файл 'source.json' не найден.");

                string jsonContent = System.IO.File.ReadAllText(filePath);
                jsonContent = jsonContent.Replace("\r\n", "");

                // Установка правильного типа содержимого
                Response.ContentType = "application/json";

                return Ok(jsonContent); // Ответ с успешным статусом 200 OK
            }
            catch (IOException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка при чтении файла: {ex.Message}");
            }
        }
    }
}