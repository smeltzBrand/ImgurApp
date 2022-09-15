namespace ImgurApp.Models
{
    public class Image
    {
        public int id { get; set; }
        public IFormFile Photo { get; set; }
        public string PhotoFileName { get; set; }
        public string Description { get; set; }
    }
}
