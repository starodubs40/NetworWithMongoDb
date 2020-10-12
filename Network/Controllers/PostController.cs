using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Network.Domain.Entities;
using Network.Services;

namespace Network.Controllers
{
    public class PostController : Controller
    {

        private readonly PostService postService;
        private readonly ProfileService profileService;

        public PostController(PostService postService , ProfileService profileService)
        {
            this.postService = postService;
            this.profileService = profileService;
            
        }

        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = profileService.Get(id);
            ViewBag.Profile = profile;

            var posts = postService.GetAllById(id);
            ViewBag.Posts = posts;

            if (profile == null)
            {
                return NotFound();
            }
            return View();
        }



        public ActionResult PhotoZoom(string id)
        {
            var post = postService.Get(id);
            
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }


        
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                postService.Create(post);
                return Redirect("/Profile/Index");
            }
            return View(post);

        }

     
        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

       
        // GET: PostController/Delete
        public ActionResult Delete(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var post = postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var post = postService.Get(id);

                if (post == null)
                {
                    return NotFound();
                }

                postService.Remove(post);

                return Redirect("/Profile/Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
