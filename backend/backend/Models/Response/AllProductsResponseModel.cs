using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class AllProductsResponseModel
    {
        public int focusAreaId { get; set; }
        public int productId { get; set; }
        public string item { get; set; }
        public double ratePerHour { get; set; }
        public double timeStudyPerTest { get; set; }
    }
}
