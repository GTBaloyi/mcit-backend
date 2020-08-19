using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.DataAccess.Database.Entities
{
    [Table("quotation_item")]
    public class QuotationItemEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string FocusArea { get; set; }
        public string Item { get; set; }
        public double numberOfTests { get; set; }
        public double Unit_Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string quote_reference { get; set; }
    }
}