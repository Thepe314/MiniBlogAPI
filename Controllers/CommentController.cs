using Microsoft.AspNetCore.Mvc;
using MINIBLOGAPI.Repository;
using MINIBLOGAPI.Models;


namespace MINIBLOGAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _commentRepo;

        public CommentController( ICommentRepository commentRepo)
        {

            _commentRepo = commentRepo;
        }


        //Get /api/comment
        //returns all comment
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var post = await _commentRepo.ListAllComment();
            return Ok(post);
        }

      //Get by id : api/comment/5
      [HttpGet("{id}")]
      public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentRepo.GetbyId(id);
            if(comment == null) return NotFound("Comment not found");
            return Ok(comment);
        }

    //Post : api/comment
    [HttpPost]
        public async Task<IActionResult> Create(CommentCreateDto dto )
        {
            //Map DTO to Entity
            var comment = new Comment
            {
                PostId = dto.PostId,
                contentComment= dto.contentComment,
                author= dto.author,
                createdAt=dto.createdAt,
            };

            await _commentRepo.AddComment(comment);
            return Ok("Comment created successfully");
        }
        

        //Update the comment
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CommentCreateDto dto)
            {
                var existing = await _commentRepo.GetbyId(id);
                if(existing== null!) return BadRequest("ID mismatch");

                existing.contentComment = dto.contentComment;
                existing.author= dto.author;
                
                await _commentRepo.UpdateComment(existing);

                //Return success message
               return Ok("Comment updated successfully");
            }

        //Delete : api/comment/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id )
        {
          var existing = await _commentRepo.GetbyId(id);
          if(existing == null!) return NotFound(new {message= "Comment not found",id});

          await _commentRepo.DeleteComment(id); 
          return Ok(new{message="Succesfull deleted a comment"});

        }

       
    // OPTIONAL: Search comment by title
    // GET: api/comment/search?keyword=blog
     [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string keyword)
    {
        var comment = await _commentRepo.ListAllComment();
        var filtered = comment.Where(p => p.author.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        return Ok(filtered);
    }
    }
    
}