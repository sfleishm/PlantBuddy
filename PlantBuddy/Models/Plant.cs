using System.ComponentModel.DataAnnotations;

namespace PlantBuddy.Models
{
    public class Plant : BaseModel
    {
        public int PlantId { get; set; }
        [Required]
        public string? PlantName { get; set; }
        public string? LightPreference { get; set; }
        [Url] public string? ResourceLink { get; set; }
            
        // Relationships
        public int? StoreId { get; set; }
        public Store? Store { get; set; }

        public List<PlantPicture>? Pictures { get; set; }
        public List<WaterHistory>? WaterHistories { get; set; }
    }
}
