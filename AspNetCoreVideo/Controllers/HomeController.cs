using AspNetCoreVideo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AspNetCoreVideo.Models;
using AspNetCoreVideo.ViewModel;
using System.Linq;
using System;

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
                Genre = Enum.GetName(typeof(Genres), video.GenreId),
                Title = video.Title,
                Id = video.Id
            });
			return View(model);
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
                Genre = Enum.GetName(typeof(Genres), model.GenreId),
                Id = model.Id,
                Title = model.Title
            });
        }
	}
}
