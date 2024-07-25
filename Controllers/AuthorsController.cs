using Microsoft.AspNetCore.Mvc;
using Biblioteca.Repositories;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = new UnitOfWork();
        }
        public IActionResult Index()
        {
            var author = unitOfWork.Authors.GetAll();
            return View(author);
        }

        public IActionResult Details(int id)
        {
            var author = unitOfWork.Authors.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Authors.Add(author);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public IActionResult Edit(int id)
        {
            var author = unitOfWork.Authors.GetById(id);
            if(author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.Authors.Update(author);
                unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        public IActionResult Delete(int id)
        {
            var author = unitOfWork.Authors.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            unitOfWork.Authors.Delete(id);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
