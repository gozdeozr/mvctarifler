using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GozdeOzerBitirmeProjesi_.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Girilemez!")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Parola Boş Girilemez!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Show password")]
        public bool Showpassword { get; set; }
    }
}