using Application.Abstractions;
using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _context;

        public PostRepository(SocialDbContext context)
        {
            _context = context;
        }
        public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            _context.Posts.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async Task DeletePost(int postId)
        {
            var post = await _context.Posts
                //.Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == postId);
            if (post == null) return;

            //var comment = post.Comments.FirstOrDefault(x => x.Id == commentId);

            //if (comment == null) return;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> GetPostById(int postId)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<Post> UpdatePost(string updatedContent, int postId)
        {
            var post = await _context.Posts.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == postId);
            if (post == null) throw new ArgumentNullException(nameof(post));
            post.LastModified = DateTime.Now;
            post.Content = updatedContent;
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
