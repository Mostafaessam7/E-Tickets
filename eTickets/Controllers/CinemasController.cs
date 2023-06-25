using eTickets.Data;
using eTickets.Models;
using eTickets.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly IRepository<Cinema> cinemaServices;

        public CinemasController(IRepository<Cinema> cinemaServices)
        {
            this.cinemaServices = cinemaServices;
        }
        public async Task<IActionResult> Index()
        {
            var data = await cinemaServices.GetAllAsync();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
           
           return  View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if(!ModelState.IsValid)
            {
                return View(cinema);
            }
            await cinemaServices.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cinema= await cinemaServices.GetEntityAsync(id);
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cinema cinema)
        {
            
            await cinemaServices.UpdateAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
           var cinema= await cinemaServices.GetEntityAsync(id);
            return View(cinema);
        }
        public async Task<IActionResult> Delete( int id)
        {
            var cinema = await cinemaServices.GetEntityAsync(id);
            if (cinema == null) { return View("NotFound"); }
            await cinemaServices.Delete(cinema);
            return RedirectToAction(nameof(Index));
        }
    }
}
