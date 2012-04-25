using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GodsOfFitness.Models {
    public class Type {
        [Key]
        public int TypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}