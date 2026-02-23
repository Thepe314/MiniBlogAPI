
using Microsoft.EntityFrameworkCore;


namespace MINIBLOGAPI.Repository
{
    
    public class CommentRepository :ICommentRepository
    {
        //readonly means only this class can access the AppDbContext.
        private readonly AppDbContext _context;

        //Making a constructor and inject ApplicationDbContext via Dependency Injection
        public CommentRepository(AppDbContext context)
        {
            _context= context;
        }

        //Retreive the all comment
        public async Task<IEnumerable<Comment>>ListAllComment()
        {
            return await _context.Comments.ToListAsync();
        }

        //Retreive comment by id
        public async Task<Comment?> GetbyId(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        //Create a new comment
        public async Task AddComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

        }

        //Update a existing coding 
        public async Task UpdateComment(Comment Comment)
        {
            var existing = await _context.Comments.FindAsync(Comment.commentID);
            if(existing == null) return;

            existing.author = Comment.author;
            existing.contentComment = Comment.contentComment;
    
            
            await _context.SaveChangesAsync();
        
        }


        //Delete comment
        public async Task DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if(comment == null) return;
            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync();

        }




    }
}