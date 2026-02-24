using System;
 namespace MINIBLOGAPI
{
    public class Post
    {
        //Attribute of post class

        public int PostId{get;set;}

        public required string Title{get;set;}

        public required string Content{get;set;}

        public DateTime createdAt{get;set;} =DateTime.Now;

        public ICollection<Comment> Comments {get;set;} =new List<Comment>();
        
    }
}