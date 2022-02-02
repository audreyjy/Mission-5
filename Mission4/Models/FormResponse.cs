using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class FormResponse
    {
        [Key]
        [Required]
        public int EntryId { get; set; }
        
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        
        public bool Edited { get; set; }        // optional
        public string Lent { get; set; }        // optional

        [Range(0,25)]                           // optional, limit to 25 characters
        public string Notes { get; set; }


        public int CategoryId { get; set; } // foreign key relationship to the category 'table' 
        public MovieCategory Category { get; set; }


    }
}
