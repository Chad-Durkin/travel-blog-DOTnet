using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Blog.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Travel_Blog.Controllers
{
    public class SearchController : Controller
    {
        private TravelBlogDbContext db = new TravelBlogDbContext();
        // GET: /<controller>/
        
            [HttpPost]
        public IActionResult Index(string searchTag)
        {
            var SearchTerm = this.Request.Form["SearchString"];
            var FoundPosts = new List<Post>();

            var FoundTag = db.Tags
                .Include(tag => tag.PostTags)
                .ThenInclude(postTags => postTags.Post)
                .FirstOrDefault(tag => tag.Name == SearchTerm);
            var ReturnPosts = new List<Post>();
            if (FoundTag != null)
            {
                foreach (var postTag in FoundTag.PostTags)
                {
                    ReturnPosts.Add(postTag.Post);
                }
            }
            return View(ReturnPosts);
        }
    }
}
