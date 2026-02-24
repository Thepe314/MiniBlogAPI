//When a user creates a comment, what should they be allowed to send?
using System;

namespace MINIBLOGAPI.Models
{
    // DTO = Data Transfer Object
    public class CommentCreateDto
    {
        // Attributes that a user can send

         public int PostId { get; set; } //Required as there is a relationship between the two.
        public string? contentComment { get; set; }  // Comment description
        public DateTime createdAt { get; set; } = DateTime.Now;  // When it was created
        public required string author { get; set; } = null!;  // Who posted it
    }
}