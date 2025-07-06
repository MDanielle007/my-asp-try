using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } = null!;

        public string Type { get; set; }

        public float Price { get; set; }

        public int? SerialNumberId { get; set; }

        public SerialNumber? SerialNumber { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }


        public List<ItemClient>? ItemClients { get; set; }
    }
}
