using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class PaymentResponseModel
    {
        public int paymentId { get; set; }
        public string invoiceReference { get; set; }
        public DateTime dateOfPayment { get; set; }
        public string paymentType { get; set; }
        public string companyRegistration { get; set; }
        public double amount { get; set; }
    }
}
