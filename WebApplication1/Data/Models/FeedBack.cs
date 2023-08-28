namespace WebApplication1.Data.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public int WindowId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public bool IsAccepted { get; set; }
    }
}
