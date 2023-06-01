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
                Slimes = _repository.GetAllSlimes(),
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult ViewSlime([FromRoute] Guid id)
        {
            var slime = _repository.GetSlime(id);

            return View(slime);
        }

        [HttpPost]
        public IActionResult BreedSlime(Guid Parent1Id, Guid Parent2Id)
        {
            var slime1 = _repository.GetSlime(Parent1Id);
            var slime2 = _repository.GetSlime(Parent2Id);

            if (slime1 == null || slime2 == null) return BadRequest("There are no slimes to breed.");

            _repository.BreedSlime(slime1, slime2);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RenameSlime(Guid id, [FromForm] string name)
        {
            var slime = _repository.GetSlime(id);

            slime.Name = name;

            _repository.UpdateSlime(slime);

            return RedirectToAction("ViewSlime", new { id = slime.ID });
        }

        [HttpPost]
        public IActionResult DeleteSlime(Guid id)
        {
            var slime = _repository.GetSlime(id);

            _repository.DeleteSlime(slime);
            return RedirectToAction("Index");
        }
    }
}
