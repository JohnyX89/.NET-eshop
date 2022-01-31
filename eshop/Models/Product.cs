using eshop.Models.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models
{
    [Table("Products")]
    public class Product : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public bool Available { get; set; }


        [NotMapped]
        [FileContentType("image")]
        public IFormFile Image { get; set; }    

        [Required]
        [StringLength(255)]
        public string ImageSrc { get; set; }
    }
}
