

namespace MINIBLOGAPI.Repository
{
    
    public interface IPostRepository 
    {

        //Get all list
        Task<IEnumerable<Post>>GetAllPost();

        //Get Post by ID
        Task <Post?>GetbyId(int id);

        //Add NEW post
        Task CreatePost (Post post);

        //UPDATE existing post

        Task UpdatePost (Post post);

        //Delete Existing post

        Task DeletePost (int id);

        //search by title
        Task<IEnumerable<Post>> Search (string title);


    }
}