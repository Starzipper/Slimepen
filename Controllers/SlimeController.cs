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
        public IActionResult GetSlime([FromQuery]Guid? id)
        {
            if (id == null) return Ok(_repository.GetAllSlimes());

            var slime = _repository.GetSlime(id);

            if (slime == null) return NotFound();

            return Ok(slime);
        }

        [HttpPost(Name = "PostSlime")]
        public IActionResult PostSlime(Slime slime)
        {
            var newSlime = new Slime
            {
                ID = Guid.NewGuid(),
                Name = slime.Name,
                Sex = slime.Sex,
                Color = slime.Color
            };
            _repository.InsertSlime(newSlime);

            return Ok(newSlime);
        }

        [HttpPut(Name = "PutSlime")]
        public IActionResult PutSlime([FromQuery]Guid id, string name)
        {
            var slime = new Slime
            {
                ID = id,
                Name = name,
                Sex = 'M',
                Color = "00FF00"
            };
            _repository.UpdateSlime(slime);

            return Ok(slime);
        }

        [HttpDelete(Name = "DeleteSlime")]
        public IActionResult DeleteSlime([FromQuery]Guid id)
        {
            _repository.DeleteSlime(id);
            return Ok();
        }
    }
}
