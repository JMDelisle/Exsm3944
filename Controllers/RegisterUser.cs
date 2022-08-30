using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exsm3945_Assignment.Controllers
{
    public class RegisterUser : Controller
    {
        //   GET: RegisterUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegisterUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegisterUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterUser/Create
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

        // GET: RegisterUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterUser/Edit/5
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

        // GET: RegisterUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterUser/Delete/5
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
