using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychologyApp.Models
{
    public class MentalDisorder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        public string? Description { get; set; }

        public string? DiagnosticCriteria { get; set; }

        public string? Treatment { get; set; }

        [ForeignKey("PsychologyType")]
        public int? PsychologyTypeId { get; set; }
        public PsychologyType? PsychologyType { get; set; }

        [ForeignKey("PsychotherapyType")]
        public int? PsychotherapyTypeId { get; set; }
        public PsychotherapyType? PsychotherapyType { get; set; }
    }
}