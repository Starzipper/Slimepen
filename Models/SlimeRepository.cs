namespace Slimepen.Models
{
    public class SlimeRepository : ISlimeRepository
    {
        public List<Slime> Slimes { get; set; }
        public Slime GetSlime(int id)
        {
            return Slimes.ElementAt(id);
        }
        public void UpdateSlime(Slime slime)
        {
            Slimes[slime.ID] = slime;
        }
        public void InsertSlime(Slime slime)
        {
            Slimes.Insert(slime.ID, slime);
        }
        public void DeleteSlime(int id)
        {
            Slimes.RemoveAt(id);
        }
    }
}
