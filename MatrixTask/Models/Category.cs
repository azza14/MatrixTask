using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MatrixTask.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public bool IsSubCat { get; set; }
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Property> Tags { get; set; }

    }
}