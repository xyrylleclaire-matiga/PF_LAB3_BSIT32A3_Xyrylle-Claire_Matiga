using System.ComponentModel.DataAnnotations;

namespace GreedIsland.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Rarity Rarity { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public string? Series { get; set; }
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        SuperRare,
        UltraRare,
        Legendary
    }
}
