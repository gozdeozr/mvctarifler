using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GozdeOzerBitirmeProjesi_.Entities
{
    public class User:BaseIdWithDate
    {
        [Required(ErrorMessage = "Ad Zorunlu Alandır")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Zorunlu Alandır")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "E-posta Zorunlu Alandır")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Zorunlu Alandır")]
        public string Password { get; set; }
        [Display(Name = "Show password")]
        public bool Showpassword { get; set; }
    }
}