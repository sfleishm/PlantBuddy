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

        public static string ConvertImage(byte[] bytes)
        {
            string imreBase64Data = Convert.ToBase64String(bytes);
            string imgDataURL = string.Format("data:image/jpeg;base64,{0}", imreBase64Data);
            return imgDataURL;
        }
    }
}
