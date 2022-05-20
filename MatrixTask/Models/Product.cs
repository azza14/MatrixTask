using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatrixTask.Models
{
    public class Product
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //public virtual ICollection<> Categories { get; set; }
        public virtual ICollection<Property> Tags { get; set; }
    }
}