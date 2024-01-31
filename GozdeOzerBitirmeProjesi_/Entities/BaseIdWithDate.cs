using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GozdeOzerBitirmeProjesi_.Entities
{
    public class BaseIdWithDate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Boolean Status { get; set; }

        [Required]
        public DateTime Createdate { get; set; }

        [Required]
        public bool Deleted { get; set; }
    }
}