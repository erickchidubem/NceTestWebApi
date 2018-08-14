using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NceTestWebApi.Models
{
    public class FamilyModel
    {
       
        [Required(ErrorMessage = "UserId can't be empty")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Text, ErrorMessage = "Name is not valid")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Text, ErrorMessage = "Relationship is not valid")]
        public string Relationship { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number is not valid")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Age { get; set; }  
        
       
        
    }
}
