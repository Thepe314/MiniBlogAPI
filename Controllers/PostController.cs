using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using MINIBLOGAPI.Models;
using MINIBLOGAPI.Repository;

namespace MINIBLOGAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepo;

        public PostController( IPostRepository postRepo)
        {

            _postRepo = postRepo;
        }


        //Get /api/post
        //returns all post
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             var posts = await _postRepo.GetAllPost();
             var response = posts.Select(p => new PostResponseDTO
                {
                    Title = p.Title,
                    Content = p.Content,
                    createdAt = p.createdAt,
                    Comments = p.Comments.Select(c => new CommentResponseDTO
                    {
                        commentID = c.commentID,
                        contentComment = c.contentComment,
                        author = c.author,
                        createdAt = c.createdAt
                    }).ToList()
                });

                return Ok(response);
        }

      //Get by id : api/post/5
      [HttpGet("{id}")]
      public async Task<IActionResult> GetById(int id)
        {
            var post = await _postRepo.GetbyId(id);
            if(post == null) return NotFound("Post not found");
            return Ok(post);
        }

    //Post : api/Post
    [HttpPost]
    public async Task<IActionResult> Create(PostCreateDto dto)
        {
            //map DTO to Entity
            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
            };

            await _postRepo.CreatePost(post);
            return Ok("Post created successfully");
        }
        

        //Update the Post
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,PostCreateDto dto)
            {
                var existing = await _postRepo.GetbyId(id);
                if(existing == null!) return BadRequest("Id mismatch");
                
                existing.Content = dto.Content;
                existing.Title = dto.Title;


                await _postRepo.UpdatePost(existing);

                //Return success message
                return Ok("Post successfully updated");
            }

        //Delete : api/post/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id )
        {
            var exisitng = await _postRepo.GetbyId(id);
            if(exisitng == null!) return NotFound(new {message= "Post not found",id});

            await _postRepo.DeletePost(id);
            return Ok(new { message = "Post deleted successfully", id });
        }

       
    // OPTIONAL: Search posts by title
    // GET: api/Post/search?keyword=blog
     [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string keyword)
    {
        var posts = await _postRepo.GetAllPost();
        var filtered = posts.Where(p => p.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        return Ok(filtered);
    }
    }
    
}