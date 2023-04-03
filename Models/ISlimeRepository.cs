namespace Slimepen.Models
{
    public interface ISlimeRepository
    {
        public List<Slime> Slimes { get; set; }
        public Slime GetSlime(Guid? id);
        public List<Slime> GetAllSlimes();
        public void UpdateSlime(Slime slime);
        public void InsertSlime (Slime slime);
        public void DeleteSlime(Guid id);
    }
}