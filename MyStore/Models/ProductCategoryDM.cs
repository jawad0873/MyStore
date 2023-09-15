using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
    public class ProductCategoryDM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public ProductDM Product { get; set; }
        public  CategoryDM Category { get; set; }
    }
}
