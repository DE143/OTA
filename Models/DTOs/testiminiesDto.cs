namespace OTA_Portal_Service.Models.DTOs
{
    public class testiminiesGetDto
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string position { get; set; }
        public string Description { get; set; }
        public IFormFile image { get; set; }
        public string imageUrl { get; set; }
        public string? status { get; set; }
        public string localDescription { get; set; }
        public string localFullName { get; set; }
        public string localPosition { get; set; }
    }

    public class testiminiesUpdateDto {
        public string fullName { get; set; }
        public string position { get; set; }
        public string Description { get; set; }
        public IFormFile image { get; set; }
        public string imageUrl { get; set; }
        public string? status { get; set; }
        public string localDescription { get; set; }
        public string localFullName { get; set; }
        public string localPosition { get; set; }
    }
}
