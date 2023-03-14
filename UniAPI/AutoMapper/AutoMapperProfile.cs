using AutoMapper;
using BookStore.Models.Models;
using BookStore.Models.Requests;

namespace UniAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddAuthorRequest, Author>();
            CreateMap<UpdateAuthorRequest, Author>();
        }
    }
}