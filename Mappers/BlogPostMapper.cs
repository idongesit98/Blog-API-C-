using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Dto;
using Blog.Models;

namespace Blog.Mappers
{
    public static class BlogPostMapper
    {
        public static PostDto ToPostDto(this Post postModel)
        {
            return new PostDto
            {
                Id = postModel.Id,
                Title = postModel.Title,
                Contents = postModel.Contents,
                Author = postModel.Author,
                Category = postModel.Category,
                Tags = postModel.Tags,
                CreatedAt = postModel.CreatedAt,
                UpdatedAt = postModel.UpdatedAt,
            };
        }

        public static Post ToPostFromPostDto (this CreateBlogPostDto createDto)
        {
            return new Post
            {
                Title = createDto.Title,
                Contents = createDto.Contents,
                Author = createDto.Author,
                Category = createDto.Category,
                Tags = createDto.Tags,
                CreatedAt = createDto.CreatedAt,
            };
        }
    }
}