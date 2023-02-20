using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission_six_movie_db.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CatId { get; set; }
        public string CategoryName { get; set; }

    }
}
