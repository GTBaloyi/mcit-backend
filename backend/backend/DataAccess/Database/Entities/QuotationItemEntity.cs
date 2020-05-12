using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Entities
{
    public class QuotationItemEntity
    {
       public string Code { get; set; }
       public string Description { get; set; }
       public string Unit_price { get; set; }
       public int Quantity { get; set; }
       public double Total { get; set; }
    }
}
