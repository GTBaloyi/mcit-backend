namespace backend.DataAccess.Database.Entities
{
    public class QuotationItemEntity
    {
        public string Description { get; set; }
        public string Unit_Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}