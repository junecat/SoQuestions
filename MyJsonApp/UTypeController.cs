using Microsoft.AspNetCore.Mvc;

namespace MyJsonApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UTypeController : ControllerBase
    {
        private readonly ILogger<UTypeController> _logger;

        public UTypeController(ILogger<UTypeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Возвращает мой тип как json
        /// </summary>
        [HttpGet(Name = "GetPerson")]
        public ActionResult<Person> Get()
        {
            Person person = new Person()
            {
                Name = "Elena Samoylova",
                Description = "ready for companyonship",
                Age = 39,
                Gender = "Female",
                Id = 112,
                Phone = "+7 999 8559911"
            };
            return person;
        }

    }


    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

}
