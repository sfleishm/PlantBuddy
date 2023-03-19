namespace PlantBuddy.Models
{
    public class PlantPicture : BaseModel
    {
        public int PlantPictureId { get; set; }

        // Relationships
        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        // Properties
        public string PictureName { get; set; }
        public byte[] Picture { get; set; }
    }
}
