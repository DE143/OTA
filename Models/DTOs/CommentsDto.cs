using OTA_Portal_Service.Models.Entities;

namespace OTA_Portal_Service.Models.DTOs
{
    public class CommentsGetDto
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string localFullName { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string localSubject { get; set; }
        public string body { get; set; }
        public IFormFile image { get; set; }
        public string imageUrl { get; set; }
        public string localBody { get; set; }
        public string? status { get; set; }
        public int? blogId { get; set; }
    }
    public class CommentsPostDto
    {
        public string fullName { get; set; }
        public string localFullName { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string localSubject { get; set; }
        public string body { get; set; }
        public IFormFile image { get; set; }
        public string imageUrl { get; set; }
        public string localBody { get; set; }
        public string? status { get; set; }
        public int blogId { get; set; }

    }
}
