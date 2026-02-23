using Microsoft.AspNetCore.Mvc;
using MINIBLOGAPI.Repository;

namespace MINIBLOGAPI
{
    [ApiController]
    [Route("api/controller")]
    
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepo;

        public PostController( IPostRepository postRepo)
        {

            _postRepo = postRepo;
        }


        //Get /api/posthttps://msdn.microsoft.com/query/roslyn.query?appId=roslyn&k=k(CS1061)
        //returns all post
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var post = await _postRepo.GetAllPost();
            return Ok(post);
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
    public async Task<IActionResult> Create(Post post)
        {
            await _postRepo.CreatePost(post);
            return CreatedAtAction (nameof(GetById), new {id = post.PostId}, post);
        }

        //Update the Post
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Post post)
        {   
            if(id !=post.PostId) return BadRequest("Cannot find id");
            {
                await _postRepo.UpdatePost(post);
                return NoContent();
            }
        }

        //Delete : api/post/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id )
        {
            await _postRepo.DeletePost(id);
            return NoContent();
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