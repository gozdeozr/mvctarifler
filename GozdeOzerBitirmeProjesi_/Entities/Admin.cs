using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GozdeOzerBitirmeProjesi_.Entities
{
    public class Admin:BaseIdWithDate
    {
        [Required(ErrorMessage = "Ad Zorunlu Alandır")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Zorunlu Alandır")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Zorunlu Alandır")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Zorunlu Alandır")]
        public string Password { get; set; }
    }
}