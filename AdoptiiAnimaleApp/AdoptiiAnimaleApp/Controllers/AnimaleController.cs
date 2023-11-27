using AdoptiiAnimaleApp.Data;
using AdoptiiAnimaleApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptiiAnimaleApp.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class AnimaleController : Controller
    {
        private Repository.AnimaleRepository _repository;
        public AnimaleController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.AnimaleRepository(dbContext);
        }

        // GET: AnimaleController
        [AllowAnonymous]
        public ActionResult Index()
        {
            var animale = _repository.GetAllAnimales();
            return View("Index",animale);
        }

        // GET: AnimaleController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetAnimaleByID(id);
            return View("DetailsAnimale",model);
        }

        // GET: AnimaleController/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View("CreateAnimale");
        }

        // POST: AnimaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAnimale(IFormCollection collection)
        {
            try
            {
                Models.AnimaleModel model = new Models.AnimaleModel();
                // Se incearca actualizarea modelului cu datele din colectia primita
                var task = TryUpdateModelAsync(model);
                // Se asteapta finalizarea operatiei asincrone
                task.Wait();
                // Daca actualizarea modelului a avut succes
                if (task.Result)
                {
                    // Se insereaza modelul actualizat in repository
                    _repository.InsertAnimale(model);
                }
                return View("CreateAnimale");
            }
            catch
            {
                return View("CreateAnimale");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AnimaleController/Edit/5

        public ActionResult Edit(Guid id)
        {
            var model=_repository.GetAnimaleByID(id);
            return View("EditAnimale", model);
        }

        // POST: AnimaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAnimale(Guid id, IFormCollection collection)
        {
            try
            {
                var model= new AnimaleModel();

                // Se incearca actualizarea modelului cu datele din colectia primita
                var task =TryUpdateModelAsync(model);
                // Se asteapta finalizarea operatiei asincrone
                task.Wait();
                // Daca actualizarea modelului a avut succes
                if (task.Result)
                {
                    // Se insereaza modelul actualizat in repository
                    _repository.UpdateAnimale(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index",id);
                }
                
            }
            catch
            {
                return RedirectToAction("Index", id);

            }
        }

        // GET: AnimaleController/Delete/5
        
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetAnimaleByID(id);
            return View("DeleteAnimale", model);
        }

        // POST: AnimaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnimale(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteAnimale(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteAnimale",id);
            }
        }
    }
}
