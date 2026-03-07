namespace InventoryApp.Models
{
    public class DashboardViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalUsers { get; set; }
        public int TotalCategories { get; set; }
        public List<Product> LatestProducts { get; set; } = new();
    }
}
