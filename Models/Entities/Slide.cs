namespace OTA_Portal_Service.Models.Entities
{
    public class Slide
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string localTitle { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public string imagePath { get; set; }
        public string? status { get; set; }
    }
}
