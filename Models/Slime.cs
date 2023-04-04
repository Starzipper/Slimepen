namespace Slimepen.Models
{
    public class Slime
    {
        public Guid ID { get; init; }
        public string Name { get; set; } = "Slime";
        public char Sex { get; init; } = 'M';
        public string Color { get; init; } = "000000";
    }
}
