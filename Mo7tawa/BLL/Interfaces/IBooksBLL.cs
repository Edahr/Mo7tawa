using Mo7tawa.DAL.Data.Models;

namespace Mo7tawa.BLL.Interfaces
{
    public interface IBooksBLL
    {
        Task<Book> AddBookAsync(Book book);
        Task<Book> DeleteBookAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> UpdateBookAsync(int id, Book bookUpdated);
    }
}