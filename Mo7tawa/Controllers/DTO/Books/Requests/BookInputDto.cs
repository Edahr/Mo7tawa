namespace Mo7tawa.Controllers.DTO.Books.Requests
{
    public class BookInputDto
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        public required DateTime PublishDate { get; set; }
    }
}
