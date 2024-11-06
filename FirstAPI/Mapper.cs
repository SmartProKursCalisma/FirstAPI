using AutoMapper;
using FirstAPI.Dtos.PersonelDtos;
using FirstAPI.Models;

namespace FirstAPI
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<PersonelCreateDto, Personel>().ReverseMap();
            CreateMap<Personel, PersonelUpdateDto>().ReverseMap();
        }
    }
}
