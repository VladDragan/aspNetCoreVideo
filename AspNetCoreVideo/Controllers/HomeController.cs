using AspNetCoreVideo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AspNetCoreVideo.Models;
using AspNetCoreVideo.ViewModel;
using System.Linq;
using System;
using AspNetCoreVideo.Entities;

namespace AspNetCoreVideo.Controllers
{
	public class HomeController : Controller
	{
        private readonly IVideoData _videos;

        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }

        public ViewResult Index()
		{
            var model = _videos.GetAll().Select(video =>
            new VideoViewModel
            {
                Genre = video.Genre.ToString(),
                Title = video.Title,
                Id = video.Id
            });
			return View(model);
		}

        [HttpPost]
        public IActionResult Create(VideoEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var video = new Video
                {
                    Genre = model.Genre,
                    Id = model.Id,
                    Title = model.Title
                };
                _videos.Add(video);
                return RedirectToAction("Details", new { id = video.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }

        public IActionResult Details(int id)
        {
            var model = _videos.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(new VideoViewModel
            {
                Genre = model.Genre.ToString(),
                Id = model.Id,
                Title = model.Title
            });
        }
	}
}
