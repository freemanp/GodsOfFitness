using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GodsOfFitness.Models {
    public class Routine {
        [Key]
        public int RoutineId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Type Type { get; set; }

    }
}