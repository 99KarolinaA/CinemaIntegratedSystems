using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Domain;
using Cinema.Domain.DomainModels;
using Cinema.Domain.Enum;
using Cinema.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly UserManager<CinemaUser> userManager;

        public MoviesController(IMovieService movieService, UserManager<CinemaUser> userManager)
        {
            this.movieService = movieService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var all = movieService.GetAllMovies();
            return View(all);
        }

        public IActionResult Create()
        {
            ViewData["genres"] = new SelectList(Enum.GetValues(typeof(Genre)));
            return View();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Length,Image,Genre")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.movieService.CreateNewMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        // GET: Tickets/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = this.movieService.GetDetailsForMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        // GET: Tickets/Edit/5
        public IActionResult Edit(Guid? id)
        {
            ViewData["genres"] = new SelectList(Enum.GetValues(typeof(Genre)));

            if (id == null)
            {
                return NotFound();
            }

            var movie = this.movieService.GetDetailsForMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Title,Length,Image,Genre")] Movie movie)
        {
            //Presentation for some content - so we write them in the controller
            if (id != movie.Id)
            {
                return NotFound();
            }
            //not found - message - view 

            if (ModelState.IsValid) //where to redirect
            {
                try
                {
                    this.movieService.UpdateExistingMovie(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Tickets/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = this.movieService.GetDetailsForMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this.movieService.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }
        private bool MovieExists(Guid id)
        {
            return this.movieService.GetDetailsForMovie(id) != null;
        }
    }
}