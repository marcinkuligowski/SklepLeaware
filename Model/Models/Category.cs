using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Category
    {
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
