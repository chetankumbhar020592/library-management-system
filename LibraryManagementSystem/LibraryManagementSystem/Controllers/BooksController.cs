using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
namespace LibraryManagementSystem.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly List<Books> Books = new()
        {
            new Books { Id = 1, Title = "C# in Depth", IsCheckedOut = false },
            new Books { Id = 2, Title = "Clean Code", IsCheckedOut = false },
            new Books { Id = 3, Title = "The Pragmatic Programmer", IsCheckedOut = false }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Books>> GetBooks()
        {
            return Ok(Books);
        }

        [HttpPost("checkout")]
        public IActionResult CheckoutBook([FromBody] BookActionRequest request)
        {
            var book = Books.FirstOrDefault(b => b.Id == request.BookId);
            if (book == null)
                return NotFound("Book not found.");

            if (book.IsCheckedOut)
                return BadRequest("Book is already checked out.");

            book.IsCheckedOut = true;
            return Ok($"Book '{book.Title}' has been checked out.");
        }

        [HttpPost("return")]
        public IActionResult ReturnBook([FromBody] BookActionRequest request)
        {
            var book = Books.FirstOrDefault(b => b.Id == request.BookId);
            if (book == null)
                return NotFound("Book not found.");

            if (!book.IsCheckedOut)
                return BadRequest("Book is not currently checked out.");

            book.IsCheckedOut = false;
            return Ok($"Book '{book.Title}' has been returned.");
        }
    }
}
