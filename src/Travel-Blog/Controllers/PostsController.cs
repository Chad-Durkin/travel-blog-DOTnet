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
    public class PostsController : Controller
    {
        private TravelBlogDbContext db = new TravelBlogDbContext();
        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            var locationTarg = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            ViewBag.LocationName = locationTarg.Name;
            ViewBag.CurrentId = id;

            var locationsPosts = db.Posts.Where(posts => posts.LocationId == id);
            return View(locationsPosts);
        }

        public IActionResult Create(int id)
        {
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name");
            return View(new Post { LocationId = id });
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index/" + post.LocationId);
        }

        public IActionResult Delete(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            return View(thisPost);
        }

        [HttpPost]
        public IActionResult Delete(Post post)
        {
            //var holderId = post.LocationId;
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index/" + post.LocationId);
        }

        public IActionResult Edit(int id)
        {
            var thisPost = db.Posts.FirstOrDefault(posts => posts.PostId == id);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Name");
            return View(thisPost);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index/" + post.LocationId);
        }
    }
}
