using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Helper;
using Blog.Dto;
using Blog.Models;


namespace Blog.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllAsync(QueryObject query);
        Task<Post> CreateAsync(Post createPost);
        Task<Post?> GetByIdAsync(int id);
        Task<Post?> UpdateAsync(int id, UpdateBlogPost blogPost);
        Task<Post?> DeleteAsync(int id);
    }
}