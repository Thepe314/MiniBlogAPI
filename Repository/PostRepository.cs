
using Microsoft.EntityFrameworkCore;

namespace MINIBLOGAPI.Repository
{
    public class PostRepository :IPostRepository
    {
        //readonly which means only this class can access the db
        private readonly AppDbContext _context;
        
        //Making a constructor and inject ApplicationDbContext via Dependency Injection
        public PostRepository(AppDbContext context)
        {
             _context = context;

        }

        //Get all Post
        public async Task<IEnumerable<Post>>GetAllPost()
        {
            return await _context.Posts.ToListAsync();
        }

        //Get by id
        public async Task<Post?>GetbyId(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        //Create new post

        public async Task CreatePost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        //Update the post
        public async Task UpdatePost(Post post)
        {
            var existing = await _context.Posts.FindAsync(post.PostId);
             if(existing == null) return;

             existing.Title = post.Title;
             existing.Content = post.Content;

            await _context.SaveChangesAsync();

        }

        //Delete post 
        public async Task DeletePost(int id)
        {
            var existing = await _context.Posts.FindAsync(id);
                if(existing == null) return;
                _context.Posts.Remove(existing);

            await _context.SaveChangesAsync();
        }

        //Search by Title
        public async Task<IEnumerable<Post>> Search(string title)
        {
            return await _context.Posts
                .Where(p => p.Title.Contains(title))
                .ToListAsync();
        }


    }
}