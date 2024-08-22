namespace OTA_Portal_Service.Models.DTOs
{
    public class TeamMemberPostDTOs
    {
        public string fullName { get; set; }
        public string localFullName { get; set; }
        public string position { get; set; }
        public string localPosition { get; set; }
        public string? status { get; set; }
        public IFormFile image { get; set; }
        public string imageUrl { get; set; }
    }
    public class TeamMemberGetDTOs
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string localFullName { get; set; }
        public string position { get; set; }
        public string localPosition { get; set; }
        public string? status { get; set; }
        public IFormFile image { get; set; }
        public string imageUrl { get; set; }
    }
}
