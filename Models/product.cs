using System.ComponentModel.DataAnnotations;

namespace BharatCrafted.Models
{
    public class product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string description { get; set; }
    }
}
