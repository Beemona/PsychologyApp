using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychologyApp.Models
{
    // Represents the Questions table
    public class QuestionnaireQuestion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Text { get; set; } // The question itself

        // A question can have multiple answers
        public ICollection<QuestionnaireAnswer>? Answers { get; set; }
    }

    // Represents the Answers table
    public class QuestionnaireAnswer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Text { get; set; } // The answer text


        public string? Recommendation { get; set; } // Optional recommendation tied to the answer

        // Foreign key to link to the question it belongs to
        [ForeignKey("QuestionnaireQuestion")]
        public int QuestionId { get; set; }
        public QuestionnaireQuestion? Question { get; set; }

        [ForeignKey("PsychologyType")]
        public int? PsychologyTypeId { get; set; }
        public PsychologyType? PsychologyType { get; set; }

        [ForeignKey("PsychotherapyType")]
        public int? PsychotherapyTypeId { get; set; }
        public PsychotherapyType? PsychotherapyType { get; set; }
    }
}
