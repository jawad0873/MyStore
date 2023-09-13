namespace MyStore.Models
{
    public class ProductDM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public ICollection<ProductCategoryDM> Categories { get; set; }
    }
}
