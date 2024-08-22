namespace OTA_Portal_Service.Models.DTOs
{
    public class SlidePostDtos
    {
        public string title { get; set; }
        public string localTitle { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public IFormFile image { get; set; }
        public string imagePath { get; set; }
        public string? status { get; set; }
    }
    public class SlideGetDtos
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string localTitle { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public IFormFile image { get; set; }
        public string imagePath { get; set; }
        public string? status { get; set; }
    }
}
