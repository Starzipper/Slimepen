using Slimepen.Models;

namespace Slimepen.Repositories
{
    public interface ISlimeRepository
    {
        public List<Slime> Slimes { get; set; }
        public Slime GetSlime(Guid? id);
        public List<Slime> GetAllSlimes();
        public void UpdateSlime(Slime slime);
        public void InsertSlime(Slime slime);
        public void DeleteSlime(Slime slime);
        public Slime BreedSlime(Slime slime1, Slime slime2);
    }
}