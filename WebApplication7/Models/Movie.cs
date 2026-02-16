using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
// Mission 6: Model representing a movie in Joel's collection
    public class Movie
    {
        [Key]// Primary key for SQLite database
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }
}