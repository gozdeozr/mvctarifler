using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GozdeOzerBitirmeProjesi_.Entities
{
    public class Category : BaseIdWithDate
    {
        [Required(ErrorMessage = "Ad Zorunlu Alandır")]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Blog> Blogs { get; set; }
    }
}