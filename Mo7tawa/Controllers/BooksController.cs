using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mo7tawa.BLL.Interfaces;
using Mo7tawa.Controllers.DTO;
using Mo7tawa.Controllers.DTO.Books.Requests;
using Mo7tawa.Controllers.DTO.Books.Responses;
using Mo7tawa.DAL.Data.Models;

namespace Mo7tawa.Controllers
{
    [ApiController]
    [Route("api/books")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBooksBLL _booksBLL;
        private readonly IMapper _mapper;

        public BooksController(IBooksBLL booksBLL, IMapper mapper)
        {
            _booksBLL = booksBLL;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookOutputDto>> GetBookById(int id)
        {
            try
            {
                var book = await _booksBLL.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<BookOutputDto>(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<BookOutputDto>>> GetAllBooks()
        {
            try
            {
                var books = await _booksBLL.GetAllBooksAsync();
                return Ok(_mapper.Map<List<BookOutputDto>>(books));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookOutputDto>> AddBook(BookInputDto bookInputDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var book = await _booksBLL.AddBookAsync(_mapper.Map<Book>(bookInputDto));
                return Ok(_mapper.Map<BookOutputDto>(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookOutputDto>> UpdateBook(int id, BookInputDto bookInputDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var book = await _booksBLL.UpdateBookAsync(id, _mapper.Map<Book>(bookInputDto));
                return Ok(_mapper.Map<BookOutputDto>(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookOutputDto>> DeleteBook(int id)
        {
            try
            {
                var book = await _booksBLL.DeleteBookAsync(id);
                return Ok(_mapper.Map<BookOutputDto>(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
