using System.ComponentModel.DataAnnotations;

namespace e_store.models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string descp { get; set; }
        [Required]
        public string category { get; set; }
        public string imgUrl { get; set; }
        [Required]
        public string price { get; set; }
    }
}
