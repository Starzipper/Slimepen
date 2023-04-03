namespace Slimepen.Models
{
    public class SlimeRepository : ISlimeRepository
    {
        public List<Slime> Slimes { get; set; } = new List<Slime>()
        {
            new Slime
            {
                ID = Guid.NewGuid(),
                Name = "Bob",
                Sex = 'M',
                Color = "FF00FF"
            },
            new Slime
            {
                ID = Guid.NewGuid(),
                Name = "Bobbilina",
                Sex = 'F',
                Color = "00FF00"
            }
        };
        public Slime GetSlime(Guid? id)
        {
            return Slimes.First(slime => slime.ID == id);
        }
        public List<Slime> GetAllSlimes()
        {
            return Slimes;
        }
        public void UpdateSlime(Slime slime)
        {
            
        }
        public void InsertSlime(Slime slime)
        {
            Slimes.Add(slime);
        }
        public void DeleteSlime(Guid id)
        {
            var slime = Slimes.First(slime => slime.ID == id);
            Slimes.Remove(slime);
        }
    }
}
