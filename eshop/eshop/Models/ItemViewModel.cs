using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Models
{
    public class ItemViewModel
    {
        public IList<Product> Products { get; set; }

        public IList<Carousel> Carousels { get; set; }

    }
}
