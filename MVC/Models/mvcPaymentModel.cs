using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcPaymentModel
    {
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public decimal PaymentPrice { get; set; }
        public int DebtId { get; set; }
    }
}