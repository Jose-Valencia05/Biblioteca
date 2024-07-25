using Biblioteca.Models;
using Biblioteca.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork unitOfWork; //Creamos campo para UnitOfWork
        public BooksController(IUnitOfWork unitOfWork) { //Inyectamos dependencias
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var books = unitOfWork.Books.GetAll();
            return View(books); //Enviamos lista de books a la vista
        }

        public IActionResult Details(int id)
        {
            var book = unitOfWork.Books.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Books.Add(book);
                unitOfWork.SaveChanges();
                //return RedirectToAction("Index"); //Forma de direccionar al index
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = unitOfWork.Books.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
             return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Books.Update(book);
                unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public IActionResult Delete(int id) {
            var book = unitOfWork.Books.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            unitOfWork.Books.Delete(id);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
