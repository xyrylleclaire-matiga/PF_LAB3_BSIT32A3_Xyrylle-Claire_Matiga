using System.ComponentModel.DataAnnotations;

namespace GreedIsland.Models
{
    public class Card
    {
        public int Id { get; set; } // PK

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Rarity { get; set; }

        // Image path or URL
        [Display(Name = "Character Image")]
        public string ImageUrl { get; set; }

        // Extra props (feel free to add more later)
        [StringLength(500)]
        public string Description { get; set; }

        public int PowerLevel { get; set; } // example
    }
}
