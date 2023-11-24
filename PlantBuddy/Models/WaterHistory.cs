namespace PlantBuddy.Models
{
    public class WaterHistory : BaseModel
    {
        public int WaterHistoryId { get; set; }

        public DateTime WateredOn { get; set; }

        // Relationships
        public int PlantId { get; set; }
        public Plant Plant { get; set; } = default!;
    }
}
