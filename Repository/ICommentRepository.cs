namespace MINIBLOGAPI.Repository
{
    
    public interface ICommentRepository 
    {

        //Get all list
        Task<IEnumerable<Comment>> ListAllComment();

        //Get comment by ID
        Task <Comment?>GetbyId(int id);

        //Add NEW COMMENT
        Task AddComment (Comment comment);

        //UPDATE existing comment

        Task UpdateComment (Comment comment);

        //Delete Existing comment

        Task DeleteComment (int id);



    }
}