//When client GETs a comment, what should they see?

namespace MINIBLOGAPI.Models
{
    public class CommentResponseDTO
{
         //Attribute of CommentResponseDTO class
        public int commentID{get;set;} //Unique key for comment

        public string? contentComment{get;set;} //Comment description


        public DateTime createdAt{get;set;} =DateTime.Now; //When it was created 

        public required string author{get;set;} = null!; //who posted it

}
}
