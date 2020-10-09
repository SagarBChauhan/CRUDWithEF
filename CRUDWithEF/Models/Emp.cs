using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CRUDWithEF.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Emp
    {
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    public class EmployeeMetaData
    {
        [Required(ErrorMessage="Name can't be empty")]
        [StringLengthAttribute(10,MinimumLength=3)]
        public string Name { get; set; }
        [Range(20,50)]
        public int Age { get; set; }
        [RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$")]
         [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        [Display(Name="Personal Website")]
        [DataType(DataType.Url)]
        [DisplayFormat(NullDisplayText = "Personal website not specified")]
        public string PersonalWebsite { get; set; }
        [DataType(DataType.Date)]
       
        //[DisplayFormat(DataFormatString="{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime HireDate { get; set; }
    }
}