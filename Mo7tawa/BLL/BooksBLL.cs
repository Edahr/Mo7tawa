using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Mo7tawa.BLL.Interfaces;
using Mo7tawa.Controllers;
using Mo7tawa.Controllers.DTO;
using Mo7tawa.DAL.Data.Models;
using Mo7tawa.DAL.Interfaces;

namespace Mo7tawa.BLL
{
    public class BooksBLL : IBooksBLL
    {
        private readonly IRepository<Book> _booksRepository;
        private readonly ILogger<BooksController> _logger;

        public BooksBLL(IRepository<Book> booksRepository, ILogger<BooksController> logger)
        {
            _booksRepository = booksRepository;
            _logger = logger;
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            try
            {
                return await _booksRepository.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching entity with ID {Id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            try
            {
                return await _booksRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all entities");
                throw;
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            try
            {
                ValidateBook(book);
                return await _booksRepository.Add(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding entity");
                throw;
            }
        }

        public async Task<Book> UpdateBookAsync(int id, Book bookUpdated)
        {
            try
            {
                ValidateBook(bookUpdated);
                bookUpdated.Id = id;
                return await _booksRepository.Update(bookUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating entity");
                throw;
            }
        }

        public async Task<Book> DeleteBookAsync(int id)
        {
            try
            {
                return await _booksRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting entity with ID {Id}", id);
                throw;
            }
        }

        private void ValidateBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Title is required.");
            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Author is required.");
            if (string.IsNullOrWhiteSpace(book.ISBN))
                throw new ArgumentException("ISBN is required.");
            if (book.PublishDate == default)
                throw new ArgumentException("Publish date is required.");
        }
    }
}
