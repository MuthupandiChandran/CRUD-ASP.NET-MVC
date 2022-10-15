using System;
using System.ComponentModel.DataAnnotations;

namespace Nivi.Models
{

    public class Customer
    {
        public int id { get; set; }
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "first Name is required")]
        [RegularExpression("[a-zA-Z]+\\.?", ErrorMessage = "Enter valid first name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        [RegularExpression("[a-zA-Z]+\\.?", ErrorMessage = "Enter valid last name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Display(Name = "Gender")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select the gender")]
        public string Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your Email id")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select atleast one occupation")]
        public string occupation { get; set; }
    }
    public enum occupation
    {
        cricketer,
        engineer,
        doctor,
        lawyer,
        other
    }  
}
   