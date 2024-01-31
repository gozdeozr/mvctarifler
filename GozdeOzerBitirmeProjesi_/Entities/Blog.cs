using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GozdeOzerBitirmeProjesi_.Entities
{
    public class Blog : BaseIdWithDate
    {
        [Required(ErrorMessage = "Başlık Zorunlu Alandır")]
        public string Caption { get; set; }

        [Required(ErrorMessage = "Detay Zorunlu Alandır")]
        public string Detail { get; set; }

        public string Keyword { get; set; }

        [Required(ErrorMessage = "Kategori Zorunlu Alandır")]

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        public virtual Category Category { get; set; }
    }
}