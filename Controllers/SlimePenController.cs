using Microsoft.AspNetCore.Mvc;
using Slimepen.Models;
using Slimepen.Repositories;

namespace Slimepen.Controllers
{
    public class SlimePenController : Controller
    {
        private readonly ISlimeRepository _repository;

        public SlimePenController(ISlimeRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var model = new SlimeBreedingGameModel
            {
                // probably better to replace this with a call to your get slimes method in your respository.
                Slimes = _repository.GetAllSlimes(),
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult ViewSlime([FromRoute] Guid id)
        {
            // if (id == null) return Ok(_repository.GetAllSlimes());

            var slime = _repository.GetSlime(id);

            // if (slime == null) return NotFound($"Slime (ID: {id}) not found.");

            return View(slime);
        }

        [HttpPost]
        public IActionResult BreedSlime(Guid Parent1Id, Guid Parent2Id)
        {
            //if (breedingForm.Parent1Id == Guid.Empty || breedingForm.Parent2Id == Guid.Empty) return BadRequest("At least one Guid is null or empty.");

            var slime1 = _repository.GetSlime(Parent1Id);
            var slime2 = _repository.GetSlime(Parent2Id);

            //if (slime1 == null && slime2 == null) return NotFound($"Slimes (ID: {slimeID1} and ID: {slimeID2}) not found.");
            //if (slime1 == null) return NotFound($"Slime (ID: {slimeID1}) not found.");
            //if (slime2 == null) return NotFound($"Slime (ID: {slimeID2}) not found.");

            //if (slime1.ID == slime2.ID) return BadRequest("You cannot breed a slime with itself.");
            //if (slime1.Sex == slime2.Sex) return BadRequest("You cannot yield offspring from two slimes of the same sex.");

            _repository.BreedSlime(slime1, slime2);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RenameSlime(Guid id, [FromForm] string name)
        {
            var slime = _repository.GetSlime(id);

            // if (slime == null) return NotFound($"Slime (ID: {id}) not found.");

            slime.Name = name;

            _repository.UpdateSlime(slime);

            return RedirectToAction("ViewSlime", new { id = slime.ID });
        }

        [HttpPost]
        public IActionResult DeleteSlime(Guid id)
        {
            // if (id == Guid.Empty) return BadRequest("Guid was null or empty.");

            var slime = _repository.GetSlime(id);

            // if (slime == null) return NotFound($"Slime (ID: {id}) not found.");

            _repository.DeleteSlime(slime);
            return RedirectToAction("Index");
        }
    }
}
