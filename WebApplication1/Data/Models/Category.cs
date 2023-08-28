namespace WebApplication1.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Descroption { get; set; }
        public List<Window> Windows { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
