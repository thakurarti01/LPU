using Library_Book_Management.Models;

namespace Library_Book_Management.Data
{
	public interface IBookRepository
	{
		// List<Book> GetAllBooks(); --this was for in-memory work
		IEnumerable<Book> GetAllBooks();
		Book GetBookById(int id);
		void AddBook(Book book);
		void DeleteBook(int id);
	}
}
