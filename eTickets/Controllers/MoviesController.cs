using eTickets.Data;
using eTickets.Models;
using eTickets.Models.Repositories;
using eTickets.Models.Services;
using eTickets.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieServices movieServices;

        public MoviesController(IMovieServices movieServices)
        {
            this.movieServices = movieServices;
        }


        public async  Task<IActionResult> Index()
        {

         //   var data= await con.Movies.Include(e=>e.Cinema).OrderBy(e=>e.Name).ToListAsync();
            var data= await movieServices.GetAllAsync(e=>e.Cinema);
            return View(data);
        }
        public async Task<IActionResult> create()
        {
            var dropDowns= await movieServices.GetCreateMovieDropDownsValues();
            ViewBag.cinemas = new SelectList(dropDowns.Cinemas,"id","Name");
            ViewBag.Producers =new SelectList(dropDowns.Producers,"id","FullName");
            ViewBag.Actors = new SelectList(dropDowns.Actors,"id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create(CreateMovieVM createMovieVM)
        {
            if(!ModelState.IsValid)
            {
                var dropDowns = await movieServices.GetCreateMovieDropDownsValues();
                ViewBag.cinemas = new SelectList(dropDowns.Cinemas, "id", "Name");
                ViewBag.Producers = new SelectList(dropDowns.Producers, "id", "FullName");
                ViewBag.Actors = new SelectList(dropDowns.Actors, "id", "FullName");

                return View(createMovieVM);
            }
           await movieServices.AddMovieAsync(createMovieVM);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id )
        {
            var movie = await movieServices.GetMovieById(id);
            return View(movie);
        }
    }
}
