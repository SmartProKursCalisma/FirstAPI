using AutoMapper;
using FirstAPI.Dtos.PersonelDtos;

namespace FirstAPI.Models
{
    public class PersonelManager
    {
        private List<Personel> Personels { get; set; }
        private IMapper _mapper;
        public PersonelManager(IMapper mapper)
        {
            Personels = new();
            Personels.Add(new Personel() { Id = 1, Fullname = "Melih Ömer KAMAR", Job = "Yazılım Geliştirici" });
            Personels.Add(new Personel() { Id = 2, Fullname = "Mustafa BAYÇÖL", Job = "Frontend Geliştirici" });
            Personels.Add(new Personel() { Id = 3, Fullname = "Selimcan TOPAL", Job = "Backend Geliştirici" });
            _mapper = mapper;
        }
        public ResultObject<Personel> GetPersonels()
        {
            return new ResultObject<Personel>
            {
                Message = "Bütün Personellerin Listesi.",
                StatusCode = 200,
                Values = Personels,
            };
        }
        public ResultObject<Personel> GetPersonelById(int id)
        {
            var result = Personels.FirstOrDefault(x => x.Id == id);
            return new ResultObject<Personel>
            {
                Message = $"{id} Nolu Kayıt.",
                Value = result,
                StatusCode = 200
            };
        }
        public ResultObject<Personel> AddPersonel(PersonelCreateDto personelDto)
        {
            int id = Personels.Count + 1;
            var personel = _mapper.Map<Personel>(personelDto);
            var dto = _mapper.Map<PersonelCreateDto>(personel);
            personel.Id = id;
            Personels.Add(personel);
            return new ResultObject<Personel>
            {
                StatusCode = 201,
                Value = personel,
                Message = "Bir Personel Kayıdı Eklendi."
            };
        }
        public ResultObject<Personel> UpdatePersonel(Personel personel, int id)
        {
            var result = new ResultObject<Personel>();

            if (personel is not null && personel.Id == id)
            {
                var currentPersonel = Personels.FirstOrDefault(x => x.Id == id);
                currentPersonel.Job = personel.Job;
                currentPersonel.Fullname = personel.Fullname;
                result.Message = $"{id} Nolu Kayıt Güncellendi.";
                result.StatusCode = 200;
                result.Value = currentPersonel;
                return result;
            }
            result.StatusCode = 404;
            result.Error = $"{id} Nolu Kayıt Bulunamadı.";
            return result;

        }
        public ResultObject<Personel> DeletePersonel(int id)
        {
            var personel = Personels.FirstOrDefault(x => x.Id == id);
            Personels.Remove(personel);
            return new ResultObject<Personel> {StatusCode = 200,Message = $"{id} Nolu Kayıt Silindi." };
        }
    }
}
