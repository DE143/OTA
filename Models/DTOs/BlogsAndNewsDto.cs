using OTA_Portal_Service.Models.Entities;

namespace OTA_Portal_Service.Models.DTOs
{
    public class BlogsAndNewsGetDto
    {
        public int Id { get; set; }
        public string userRole { get; set; }
        public string title { get; set; }
        public string localTitle { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public string imageUrl { get; set; }
        public IFormFile image { get; set; }
        public DateTime dates { get; set; }
        public string? status { get; set; }
        public List<CommentsGetDto> comments { get; set; } = null!;
    }
    public class UpdateBlogsAndNews
    {
        public int Id { get; set; }
        public string userRole { get; set; }
        public string title { get; set; }
        public string localTitle { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public string imageUrl { get; set; }
        public IFormFile image { get; set; }
        public DateTime dates { get; set; }
        public string? status { get; set; }
    }
    public class BlogsAndNewsPostDto
    {
        public string userRole { get; set; }
        public string title { get; set; }
        public string localTitle { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public string imageUrl { get; set; }
        public IFormFile image { get; set; }
        public DateTime dates { get; set; }
        public string status { get; set; }
       
    }
}
