using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookwithcodefirst.Context;
using Microsoft.AspNetCore.Mvc;

namespace Bookwithcodefirst.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksDbContext _context;

        public BooksController(BooksDbContext context)
        {
            _context = context;
        }


        public IActionResult BooksList()
        {
            List<Book> books = _context.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult AddBook(int id)
        {
            return View(id);
        }
        [HttpPost]
        public IActionResult AddBook(Book newBook)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(newBook);
                _context.SaveChanges();
            }
            return RedirectToAction("BooksList", new { id = newBook.Id });
        }
        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            Book found = _context.Books.Find(id);
            return View(found);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book newBook)
        {
            Book oldBook = _context.Books.Find(newBook.Id);
           
            if(ModelState.IsValid)
            {
                oldBook.Title = newBook.Title;
                oldBook.Author = newBook.Author;
                _context.Entry(oldBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(oldBook);
                _context.SaveChanges();
            }
            return RedirectToAction("BooksList" );
        }
        public IActionResult DeleteBook(int id)
        {
            Book found = _context.Books.Find(id);
            if (found != null)
            {
                _context.Books.Remove(found);
                _context.SaveChanges();
            }
            return RedirectToAction("BooksList", new { id = found.Id });
        }

    }
}