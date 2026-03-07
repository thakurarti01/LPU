using Library_Book_Management.Models;
namespace Library_Book_Management.Data
{
	public class MemoryBookRepository : IBookRepository
	{
		List<Book> books = new List<Book>()
		{
			new Book{BookId = 101, Title = "book1", Author = "author1", Price = 500},
			new Book{BookId = 102, Title = "book2", Author = "author2", Price = 450},
			new Book{BookId = 103, Title = "book3", Author = "author3", Price = 600}
		};
		public IEnumerable<Book> GetAllBooks()
		{
			return books;
		}

		public Book GetBookById(int id)
		{
			return books.FirstOrDefault(b => b.BookId == id);
		}

		public void AddBook(Book book)
		{
			books.Add(book);
		}

		public void DeleteBook(int id)
		{
			var bookToRemove = books.FirstOrDefault(b => b.BookId == id);
			books.Remove(bookToRemove);
		}
	}
}
