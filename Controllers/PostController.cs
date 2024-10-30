using Blog.Data;
using Blog.Data.Helper;
using Blog.Dto;
using Blog.Interfaces;
using Blog.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController:ControllerBase
    {
        private readonly BlogContext _context;
        private readonly IPostRepository _blogRepo;

        public PostController(BlogContext context, IPostRepository blogRepo)
        {
            _context = context;
            _blogRepo = blogRepo;
        }

        //GET:
        [HttpGet]
        public async Task<IActionResult> GetAllPost([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var post = await _blogRepo.GetAllAsync(query);
            var blogDto = post.Select(s => s.ToPostDto()).ToList();
            
            return Ok(blogDto);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var blog = await _blogRepo.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }    
            return Ok(blog.ToPostDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostDto createDto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var blogModel = createDto.ToPostFromPostDto();
            await _blogRepo.CreateAsync(blogModel);  
            return CreatedAtAction(nameof(GetById), new{id = blogModel.Id}, blogModel.ToPostDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBlogPost([FromRoute]int id, [FromBody] UpdateBlogPost updateBlogDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var blogModel = await _blogRepo.UpdateAsync(id,updateBlogDto); 
            if (blogModel == null)
            {
                return NotFound();
            }

            return Ok(blogModel.ToPostDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var blogModel = await _blogRepo.DeleteAsync(id);
            
            if(blogModel == null)
                return NotFound(); 

            return NoContent();       
        }
     }
}