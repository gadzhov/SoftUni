namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;

    public class CameraController : Controller
    {
        private CameraBazaarDbContext _context;

        public CameraController(CameraBazaarDbContext context)
        {
            _context = context;
        }

        public IActionResult Add()
        {
            List<string> make = new List<string>();
            List<int> minIso = new List<int>();
            List<string> lightMetering = new List<string>();

            foreach (var m in Enum.GetValues(typeof(Make)))
            {
                make.Add(m.ToString());
            }

            foreach (var mi in Enum.GetValues(typeof(MinIso)))
            {
                minIso.Add((int)mi);
            }

            foreach (var lm in Enum.GetValues(typeof(LightMetering)))
            {
                lightMetering.Add(lm.ToString());
            }

            ViewBag.Model = new SelectList(make);
            ViewBag.MinIso = new SelectList(minIso);
            ViewBag.LightMetering = new SelectList(lightMetering);

            return View();
        }

        [HttpPost]
        public IActionResult Add(Camera camera)
        {
            using (_context)
            {
                _context.Cameras.Add(camera);
                _context.SaveChanges();
            }

            return new RedirectToActionResult("Index", "Home", null);
        }
    }
}