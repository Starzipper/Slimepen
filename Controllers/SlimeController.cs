using Microsoft.AspNetCore.Mvc;
using Slimepen.Models;

namespace Slimepen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlimeController : ControllerBase
    {
        private readonly ISlimeRepository _repository;
        public SlimeController(ISlimeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetSlime")]
        public IEnumerable<Slime> Get([FromQuery]Guid? id)
        {
            if (id == null) return _repository.GetAllSlimes();

            var slime = _repository.GetSlime(id);
            return new List<Slime>() { slime };
        }

        [HttpPost(Name = "PostSlime")]
        public IActionResult Post(string name)
        {
            var slime = new Slime
            {
                ID = Guid.NewGuid(),
                Name = name,
                Sex = 'M',
                Color = "00FF00"
            };
            _repository.InsertSlime(slime);

            return Ok(slime);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
