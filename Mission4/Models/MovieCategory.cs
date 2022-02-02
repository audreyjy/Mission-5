using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieCategory // Model for category id and name 
    {
        [Key] // assigning categoryid as the key 
        [Required] 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
