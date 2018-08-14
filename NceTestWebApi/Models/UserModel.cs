using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NceTestWebApi.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Text, ErrorMessage = "Name is not valid")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number is not valid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Password { get; set; }
    }
}
