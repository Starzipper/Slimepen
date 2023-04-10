//using Microsoft.AspNetCore.Mvc;
//using Slimepen.Models;
//using Slimepen.Repositories;
//using System.Drawing;

//namespace Slimepen.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class SlimeController : Controller
//    {
//        private readonly ISlimeRepository _repository;
//        public SlimeController(ISlimeRepository repository)
//        {
//            _repository = repository;
//        }

//        public IActionResult Index()
//        {
//            return View(_repository.GetAllSlimes());
//        }
        
//        [HttpGet(Name = "GetSlime")]
//        public IActionResult GetSlime([FromQuery] Guid id)
//        {
//            if (id == null) return Ok(_repository.GetAllSlimes());

//            var slime = _repository.GetSlime(id);

//            if (slime == null) return NotFound($"Slime (ID: {id}) not found.");

//            return Ok(slime);
//        }

//        [HttpPost(Name = "PostSlime")]
//        public IActionResult PostSlime(Slime slime)
//        {
//            var newSlime = new Slime
//            {
//                ID = Guid.NewGuid(),
//                Name = slime.Name,
//                Sex = slime.Sex,
//                Color = slime.Color
//            };
//            _repository.InsertSlime(newSlime);

//            return Ok(newSlime);
//        }

//        [Route("/Breed")]
//        [HttpPost]
//        public IActionResult BreedSlime([FromQuery] Guid slimeID1, [FromQuery] Guid slimeID2)
//        {
//            if (slimeID1 == Guid.Empty || slimeID2 == Guid.Empty) return BadRequest("At least one Guid is null or empty.");

//            var slime1 = _repository.GetSlime(slimeID1);
//            var slime2 = _repository.GetSlime(slimeID2);

//            if (slime1 == null && slime2 == null) return NotFound($"Slimes (ID: {slimeID1} and ID: {slimeID2}) not found.");
//            if (slime1 == null) return NotFound($"Slime (ID: {slimeID1}) not found.");
//            if (slime2 == null) return NotFound($"Slime (ID: {slimeID2}) not found.");

//            if (slime1.ID == slime2.ID) return BadRequest("You cannot breed a slime with itself.");
//            if (slime1.Sex == slime2.Sex) return BadRequest("You cannot yield offspring from two slimes of the same sex.");

//            var newSlime = _repository.BreedSlime(slime1, slime2);
//            return Ok(newSlime);
//        }

//        [HttpPut(Name = "PutSlime")]
//        public IActionResult PutSlime([FromQuery] Guid id, string name)
//        {
//            var slime = _repository.GetSlime(id);

//            if (slime == null) return NotFound($"Slime (ID: {id}) not found.");

//            slime.Name = name;

//            _repository.UpdateSlime(slime);

//            return Ok(slime);
//        }

//        [HttpDelete(Name = "DeleteSlime")]
//        public IActionResult DeleteSlime([FromQuery] Guid id)
//        {
//            if (id == Guid.Empty) return BadRequest("Guid was null or empty.");

//            var slime = _repository.GetSlime(id);

//            if (slime == null) return NotFound($"Slime (ID: {id}) not found.");

//            _repository.DeleteSlime(slime);
//            return Ok($"Slime (ID: {id}) deleted.");
//        }
//    }
//}
