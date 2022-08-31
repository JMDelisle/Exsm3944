using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exsm3945_Assignment.Controllers
{
    public class NewUserController : Controller
    {
        // GET: NewUserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewUserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewUserController/Create
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

        // GET: NewUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewUserController/Edit/5
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

        // GET: NewUserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewUserController/Delete/5
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
