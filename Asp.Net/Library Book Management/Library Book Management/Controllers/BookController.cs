using Library_Book_Management.Data;
using Library_Book_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Book_Management.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookRepository _repo;

		public BookController(IBookRepository repo)
		{
			_repo = repo;
		}

		// GET: BookController
		public ActionResult Index()
		{
			var books = _repo.GetAllBooks();
			return View(books);
		}

		// GET: BookController/Details/5
		public ActionResult Details(int id)
		{
			var book = _repo.GetBookById(id);
			return View(book);
		}

		// GET: BookController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BookController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Book book)
		{
			try
			{
				_repo.AddBook(book);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BookController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: BookController/Edit/5
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

		// GET: BookController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: BookController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				_repo.DeleteBook(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
