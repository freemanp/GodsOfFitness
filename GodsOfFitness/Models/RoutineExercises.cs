using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GodsOfFitness.Models {
    public class RoutineExercises {
        [Required]
        public int RoutineId { get; set; }
        [Required]
        public int ExerciseId { get; set; }

        public int Sets { get; set; }
        public int Reps { get; set; }
        public int SortOrder { get; set; }
        public int Schedule { get; set; }
    }
}