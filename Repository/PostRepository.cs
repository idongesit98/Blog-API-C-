using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Data.Helper;
using Blog.Dto;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public PostRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task<Post> CreateAsync(Post postModel)
        {
            await _context.Post.AddAsync(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<List<Post>> GetAllAsync(QueryObject query)
        {
            var blogPost = _context.Post.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                blogPost = blogPost.Where(c => c.Title.Contains(query.Title));
            }

            if (!string.IsNullOrWhiteSpace(query.Contents))
            {
                blogPost = blogPost.Where(c => c.Contents.Contains(query.Contents));
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await blogPost.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _context.Post.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Post?> UpdateAsync(int id, UpdateBlogPost postDto)
        {
            var existingPost = await _context.Post.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPost == null)
                return null;

            existingPost.Title = postDto.Title;
            existingPost.Author = postDto.Author;
            existingPost.Contents = postDto.Contents;
            existingPost.Category = postDto.Category;
            existingPost.UpdatedAt = postDto.UpdatedAt;

            await _context.SaveChangesAsync();
            return existingPost;    
        } 

        public async Task<Post?> DeleteAsync(int id)
        {
            var blogModel = await _context.Post.FirstOrDefaultAsync(x => x.Id == id);
            if (blogModel == null)
                return null;

            _context.Post.Remove(blogModel);
            await _context.SaveChangesAsync();
            return blogModel;    
        }      
    }
}