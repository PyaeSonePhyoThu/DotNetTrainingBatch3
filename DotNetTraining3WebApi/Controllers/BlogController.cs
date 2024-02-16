using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DotNetTraining3WebApi.EFCoreExamples;
using DotNetTraining3WebApi.Models;
using System.Reflection;

namespace DotNetTraining3WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController()
        {
               _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> lst = _db.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlogs(int id, BlogModel blog)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                return NotFound("No Data Found");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            int result = _db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Update Fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                return NotFound("No Data Found");
            }

            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Delete Fail";
            return Ok(message);
        }
     
    }
}
