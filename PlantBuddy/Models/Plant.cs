using System.ComponentModel.DataAnnotations;

namespace PlantBuddy.Models
{
    public class Plant : BaseModel
    {
        public int PlantId { get; set; }
        [Required]
        public string PlantName { get; set; }
        public string? LightPreference { get; set; }
        
        // Relationships
        public List<PlantPicture>? Pictures { get; set; }
    }
}
