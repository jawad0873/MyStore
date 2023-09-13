namespace MyStore.Models
{
    public class CategoryDM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductCategoryDM> Products { get; set; }
    }
}
