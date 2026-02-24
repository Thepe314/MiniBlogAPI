
//When client GETs a comment, what should they see?

namespace MINIBLOGAPI.Models
{
    public class PostResponseDTO
{
         //Attribute of PostResponseDTO class

        public required string Title{get;set;}

        public required string Content{get;set;}

        public DateTime createdAt{get;set;} =DateTime.Now;

         // List of comments
        public List<CommentResponseDTO> Comments { get; set; } = new();


}
}
