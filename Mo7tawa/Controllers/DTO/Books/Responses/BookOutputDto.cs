namespace Mo7tawa.Controllers.DTO.Books.Responses
{
    public class BookOutputDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        public required DateTime PublishDate { get; set; }
    }
}
