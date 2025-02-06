using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychologyApp.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhotoUrl { get; set; }  // URL to the partner's photo

        [ForeignKey("PsychologyType")]
        public int? PsychologyTypeId { get; set; }
        public PsychologyType? PsychologyType { get; set; }

        [ForeignKey("PsychotherapyType")]
        public int? PsychotherapyTypeId { get; set; }
        public PsychotherapyType? PsychotherapyType { get; set; }

        public string Tags { get; set; }  // Comma-separated tags (e.g., "anxiety, stress, depression")
    }
}
