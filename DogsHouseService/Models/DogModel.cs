using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogsHouseService.Models
{
    public class DogModel
    {
        [Required(ErrorMessage ="Need to name dog")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Need to color dog")]
        public string Color { get; set; }
        [Required]
        [Range(0, 2000, ErrorMessage = "TailLength can't be negative")]
        public decimal Length { get; set; }
        [Required]
        [Range(0, 2000, ErrorMessage = "Weight can't be negative")]
        public decimal Weight { get; set; }

    }
}
