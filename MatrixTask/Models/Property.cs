using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MatrixTask.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string PropName { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        //public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public virtual Category Category { get; set; }
    }
}