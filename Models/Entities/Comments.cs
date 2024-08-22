namespace OTA_Portal_Service.Models.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string localFullName { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string localSubject { get; set; }
            public string body { get; set; }
        public string imageUrl { get; set; }
        public string localBody { get; set; }
        public string? status { get; set; }
        public int blogId { get; set; }
        public virtual BlogsAndNews blog { get; set; } = null!;

    }
}
