using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplication.Dtos.Products
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime PlantingDate { get; set; }
    }
}