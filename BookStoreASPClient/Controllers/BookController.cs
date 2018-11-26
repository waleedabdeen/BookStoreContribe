using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreASPClient.Modules.ApiModule;
using BookStoreASPClient.Models;
using System.Threading.Tasks;

namespace BookStoreASPClient.Controllers
{
    public class BookController : Controller
    {
        BookstoreService bookstoreService;
        public BookController()
        {
            bookstoreService = new BookstoreService(); 
        }
        // GET: Book
        public async Task<ActionResult> Index()
        {
            Task<IEnumerable<IBookDTO>> task = bookstoreService.GetBooksAsync();
            task.Start();
            IEnumerable<IBookDTO> books = await task;
            return View(books);
        }

        [HttpGet]
        public async Task<ActionResult> Search(string keyword)
        {
            Task<IEnumerable<IBookDTO>> task = bookstoreService.GetBooksAsync(keyword);
            task.Start();
            IEnumerable<IBookDTO> books = await task;
            ViewBag.SearchKey = keyword;
            return View("Index",books);
        }

        // GET: Book/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpNotFoundResult();
            }
            Task<IBookDTO> task = bookstoreService.GetBookDetailsAsync(id);
            task.Start();
            string message = Request.QueryString["Message"];
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
            }
            return View(await task);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
