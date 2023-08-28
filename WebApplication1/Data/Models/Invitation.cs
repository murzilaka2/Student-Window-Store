namespace WebApplication1.Data.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public string Href { get; set; }
        public string Code { get; set; }
        public DateTime GeneratedDate { get; set; }
        public bool IsUsed { get; set; }
    }
}
