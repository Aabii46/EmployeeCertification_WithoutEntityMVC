using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeCertification_WithoutMVC.Models
{
    public class tbl_Login
    {
        public int id { get; set; }

        [Required(ErrorMessage= "Username is Required")]
        [StringLength(100)]
        public string uname { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(100)]
        public string pwd { get; set; }


    }
}