using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GodsOfFitness.Models {
    public class Exercise {
        [Key]
        public int ExcerciseId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string DemoLink { get; set; }

        public virtual User User { get; set; }
    }
}