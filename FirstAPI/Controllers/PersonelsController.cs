using FirstAPI.Dtos.PersonelDtos;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelsController : ControllerBase
    {
        private readonly PersonelManager _personelManager;
        public PersonelsController(PersonelManager personelManager)
        {
            _personelManager = personelManager;
        }
        [HttpGet]
        public IActionResult GetAllPersonel()
        {
            var result = _personelManager.GetPersonels();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetPersonelById([FromRoute] int id)
        {
            var result = _personelManager.GetPersonelById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreatePersonel([FromBody] PersonelCreateDto personel)
        {
            var result = _personelManager.AddPersonel(personel);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePersonel([FromBody]Personel personel, [FromRoute]int id)
        {
            var result = _personelManager.UpdatePersonel(personel, id); 
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult RemovePersonel(int id)
        {
            var result =  _personelManager.DeletePersonel(id);
            return Ok(result);
        }
    }
}
