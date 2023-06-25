using eTickets.Data;
using eTickets.Models;
using eTickets.Models.Repositories;
using eTickets.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IRepository<Actor> actorService;

        public ActorsController( IRepository<Actor> actorService)
        {
            this.actorService = actorService;
        }

        public async Task<IActionResult> Index()
        {
            var data= await actorService.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await actorService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
         }

        public async Task<IActionResult> Details(int id)
        {
            var actor= await actorService.GetEntityAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await actorService.GetEntityAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Actor actor)
        {
            await actorService.UpdateAsync(actor);
           
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id )
        {
         
          var actor = await actorService.GetEntityAsync(id);
          if (actor == null) { return View("NotFound"); }
           await actorService.Delete(actor);
          return RedirectToAction(nameof(Index));
        }

    }
}
