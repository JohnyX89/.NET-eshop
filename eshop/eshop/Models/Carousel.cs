﻿using eshop.Models.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models
{
    [Table("Carousel")]     // table name
    public class Carousel : Entity
    {
        [Required]
        public string DataTarget { get; set; }

        [NotMapped]
        [FileContentType("image")]  
        public IFormFile Image { get; set; }    // interface which represents image sent by HTTP request

        [Required]
        [StringLength(255)]
        public string ImageSrc { get; set; }
        
        
        [Required]
        [StringLength(25)]
        public string ImageAlt { get; set; }

        [Required]
        public string CarouselContent { get; set; }

    }
}
