using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptiiAnimaleApp.Controllers
{
    public class AdoptiiController : Controller
    {
        // GET: AdoptiiController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdoptiiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdoptiiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdoptiiController/Create
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

        // GET: AdoptiiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdoptiiController/Edit/5
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

        // GET: AdoptiiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdoptiiController/Delete/5
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
