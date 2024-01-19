using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace aspClientApp.Models
{
    //servis tarafından aldığım dataları asp Core tarafında objeye çeviricem (products objesi)
    public class ProductDTO
    {
        [JsonPropertyName("productId")]//json data da ki yani veritabanında ki ismini yazdım ve ben burda artık başka isimde varsem o veriyi getircek
        public int ProductId { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; } = null!;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}