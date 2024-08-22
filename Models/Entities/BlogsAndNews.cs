namespace OTA_Portal_Service.Models.Entities
{
    public class BlogsAndNews
    {
        public int Id { get; set; }
        public string userRole { get; set; }
        public string title { get; set; }
        public string localTitle { get; set; }
        public string Description { get; set; }
        public string localDescription { get; set; }
        public string imageUrl { get; set; }
        public DateTime dates { get; set; }
            public string status { get; set; }
        public ICollection<Comments> comments { get; set; }
                
    }
}
