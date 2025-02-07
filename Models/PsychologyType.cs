using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PsychologyApp.Models
{
    public class PsychologyType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Domain { get; set; }

        public string? Description { get; set; }

        // Foreign key relationship
        public ICollection<MentalDisorder>? MentalDisorders { get; set; }
    }
}
