namespace Slimepen.Models
{
    public interface ISlimeRepository
    {
        public List<Slime> Slimes { get; set; }
        public Slime GetSlime(int id);
        public void UpdateSlime(Slime slime);
        public void InsertSlime (Slime slime);
        public void DeleteSlime(int id);
    }
}