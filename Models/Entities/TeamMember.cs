namespace OTA_Portal_Service.Models.Entities
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string localFullName { get; set; }
        public string position { get; set; }
        public string localPosition { get; set; }
        public string? status { get; set; }
        public string imageUrl { get; set; }


    }
}
