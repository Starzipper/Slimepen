using Slimepen.Models;

namespace Slimepen.Repositories
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
                Color = "FF0000"
            },
            new Slime
            {
                ID = Guid.NewGuid(),
                Name = "Bobbette",
                Sex = 'F',
                Color = "0000FF"
            }
        };
        public Slime GetSlime(Guid id)
        {
            return Slimes.First(slime => slime.ID == id);
        }
        public List<Slime> GetAllSlimes()
        {
            return Slimes;
        }
        public void UpdateSlime(Slime slime)
        {
            var index = Slimes.FindIndex(existingSlime => existingSlime.ID == slime.ID);
            Slimes[index] = slime;
        }
        public void InsertSlime(Slime slime)
        {
            Slimes.Add(slime);
        }
        public void DeleteSlime(Slime slime)
        {
            Slimes.Remove(slime);
        }
        public Slime BreedSlime(Slime slime1, Slime slime2)
        {
            var random = new Random();
            var randNum = random.Next(2);

            var sex = 'F';
            if (randNum == 0) sex = 'M';

            var color = Hexadecimal.AverageHex(slime1.Color, slime2.Color);

            var newSlime = new Slime
            {
                ID = Guid.NewGuid(),
                Name = "Slime",
                Sex = sex,
                Color = color
            };

            Slimes.Add(newSlime);

            return newSlime;
        }
    }
}
