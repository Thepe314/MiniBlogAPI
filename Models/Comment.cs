using System;

 namespace MINIBLOGAPI
{
    public class Comment
    {
        //Attribute of comment class

        public int commentID{get;set;} //Unique key for comment

        public string? contentComment{get;set;} //Comment description

        public int PostId{get;set;} // Foreign key referencing Post model

        public DateTime createdAt{get;set;} =DateTime.Now; //When it was created 

        public required string author{get;set;} //who posted it

        public Post Post {get;set;} = null!; //If comment exist post should have it.

        
    }
}