using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcCustomerModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Name and Surname are required!!!!")]
        public string NameSurname { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
    }
}