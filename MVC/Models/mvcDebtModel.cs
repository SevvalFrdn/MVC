using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcDebtModel
    {
        public int DebtId { get; set; }
        public decimal DebtPrice { get; set; }
        public decimal DebtMaturity { get; set;}
        public string DebtStatus { get; set; }
        public int CustomerId { get; set; }
    }
}