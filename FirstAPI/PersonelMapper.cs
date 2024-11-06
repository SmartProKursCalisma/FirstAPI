using FirstAPI.Dtos.PersonelDtos;
using FirstAPI.Models;

namespace FirstAPI
{
    public static class PersonelMapper
    {
        public static Personel PersonelCreateDtoToPersonel(PersonelCreateDto dto)
        {
            return new Personel()
            {
                Fullname = dto.Fullname,
                Job = dto.Job,
            };
            
        }
    }
}
