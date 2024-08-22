namespace OTA_Portal_Service.Models.DTOs
{
    public class contactUsGetDto
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string localFullName { get; set; }
        public string Email { get; set; }
        public string subject { get; set; }
        public string localSubject { get; set; }
        public string body { get; set; }
        public string localBody { get; set; }
        public string? status { get; set; }
    }
    public class contactUsPostDto
    {
        public string fullName { get; set; }
        public string localFullName { get; set; }
        public string Email { get; set; }
        public string subject { get; set; }
        public string localSubject { get; set; }
        public string body { get; set; }
        public string localBody { get; set; }
        public string? status { get; set; }
    }
}
