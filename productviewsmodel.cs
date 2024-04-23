using System.ComponentModel.DataAnnotations;

namespace BharatCrafted
{
    public class productviewsmodel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string price { get; set; }
        public IFormFile photo { get; set; }
        public string description { get; set; }
    }
}
