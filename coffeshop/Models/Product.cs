using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffeshop.Models
{
    [Table("product")]
    public class Product
    {
        // [Key] để chỉ định đây là khóa chính.
        // [Column("id")] EF Core thường tự động map "Id" sang "id", nhưng chỉ định rõ sẽ tốt hơn.
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Ánh xạ thuộc tính Name sang cột name
        [Column("name")]
        public string? Name { get; set; }

        // Ánh xạ thuộc tính Status sang cột status
        [Column("status")]
        public int Status { get; set; }

        // Ánh xạ thuộc tính Cuid sang cột cuid
        [Column("price")]
        public float Price { get; set; }

        // Rất quan trọng: Ánh xạ thuộc tính PascalCase "ProductCode" sang cột "product_code"
        [Column("product_code")]
        public string? ProductCode { get; set; }

        // Rất quan trọng: Ánh xạ thuộc tính "CreatedDate" sang cột "created_date"
        // Kiểu DateTimeOffset trong C# map tốt nhất với TIMESTAMPTZ trong PostgreSQL vì nó lưu cả thông tin múi giờ.
        [Column("created_date")]
        public DateTimeOffset? CreatedDate { get; set; }
    }

}