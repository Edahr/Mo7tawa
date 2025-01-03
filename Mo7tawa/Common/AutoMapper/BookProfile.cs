using AutoMapper;
using Mo7tawa.Controllers.DTO.Books.Requests;
using Mo7tawa.Controllers.DTO.Books.Responses;
using Mo7tawa.DAL.Data.Models;

namespace Mo7tawa.Common.AutoMapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookOutputDto>().ReverseMap();
            CreateMap<Book, BookInputDto>().ReverseMap();
        }
    }
}