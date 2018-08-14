using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NceTestWebApi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }

    }
}
