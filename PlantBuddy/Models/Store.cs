namespace PlantBuddy.Models
{
    public class Store : BaseModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public string? StoreAddress { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        // Relationships
        public List<Plant>? PlantsBoughtFromStore { get; set; }
    }
}
