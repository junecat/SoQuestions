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
        /// ���������� ���������� ������������ JSON �����
        /// </summary>
        [HttpGet(Name = "GetData")]
        public IActionResult Get()
        {
            try
            {
                // ���� � ����� ������������ �������� ��������
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "src/source.json");

                if (!System.IO.File.Exists(filePath))
                    return NotFound("���� 'source.json' �� ������.");

                string jsonContent = System.IO.File.ReadAllText(filePath);
                jsonContent = jsonContent.Replace("\r\n", "");

                // ��������� ����������� ���� �����������
                Response.ContentType = "application/json";

                return Ok(jsonContent); // ����� � �������� �������� 200 OK
            }
            catch (IOException ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, $"������ ��� ������ �����: {ex.Message}");
            }
        }
    }
}