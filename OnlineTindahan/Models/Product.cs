namespace OnlineTindahan.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductGroup { get; set; }
        public string ProductClassification { get; set; }
        public string ProductBrand { get; set; }
        public int WarrantyInDays { get; set; }
        public int AvailableQuantity { get; set; }
        public double ProductPrice { get; set; }
    }
}