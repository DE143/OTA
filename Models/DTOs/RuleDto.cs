namespace OTA_Portal_Service.Models.DTOs
{
    public class RuleGetDto
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string localTitle { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public string? status { get; set; }
    }
    public class RulePostDto
    {
        public string title { get; set; }
        public string localTitle { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public string? status { get; set; }
    }
}
