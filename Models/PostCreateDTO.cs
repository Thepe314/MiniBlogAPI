//When a user creates a comment, what should they be allowed to send?
using System;

namespace MINIBLOGAPI.Models
{
    // DTO = Data Transfer Object
    public class PostCreateDto
    {
        // Attributes that a user can send
        public required string Title{get;set;}

        public required string Content{get;set;}


    }
}