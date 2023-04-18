using AutoMapper;
using BookStore.Models.Models;
using BookStore.Models.Requests;
using BookStore.Models.Requests.BookRequests;

namespace UniAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddAuthorRequest, Author>();
            CreateMap<UpdateAuthorRequest, Author>();

            CreateMap<AddBookRequest, Book>();  
        }
    }
}