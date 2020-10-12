using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Network.Domain.Entities;
using Network.Services;

namespace Network.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ProfileService profileService;
        private readonly PostService postService;

        public ProfileController (ProfileService profileService , PostService postService)
        {
            this.profileService = profileService;
            this.postService = postService;
        }

        // GET: ProfileController
        public ActionResult Index()
        {
            return View(profileService.Get());
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(string id)
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



        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
