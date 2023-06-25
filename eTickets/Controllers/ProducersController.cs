using eTickets.Data;
using eTickets.Models;
using eTickets.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IRepository<Producer> producerService;

        public ProducersController(IRepository<Producer>  producerService )
        {
            this.producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var producers= await producerService.GetAllAsync();
            return View(producers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            await producerService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id )
        {
            var producer= await producerService.GetEntityAsync(id);
            if (producer == null) { return View("NotFound"); }
            return View(producer);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await producerService.GetEntityAsync(id);   
            return View(producer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Producer producer)
        {
            await producerService.UpdateAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id  )
        {
           var producer= await producerService.GetEntityAsync(id);

            if (producer==null) { return View("NotFound"); }
             await  producerService.Delete(producer);
            return RedirectToAction(nameof(Index));
        }

    }
}
