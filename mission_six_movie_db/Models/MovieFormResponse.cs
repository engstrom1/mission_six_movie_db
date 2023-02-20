﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// movie form class with validation
namespace mission_six_movie_db.Models
{
    public class MovieFormResponse
    {
        [Key]
        [Required]
        public int MovieFormId { get; set; }

        // set relationship to other table
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }

    }
}
