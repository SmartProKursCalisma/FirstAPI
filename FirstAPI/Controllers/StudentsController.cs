using FirstAPI.Dao;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly StudentRepository _studentRepository;

        public StudentsController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result =await  _studentRepository.GetAllStudentsAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute]int id)
        {
            var result = _studentRepository.GetStudentByIdAsync(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody]Student student)
        {
            var result = await _studentRepository.UpdateStudent(student);
            return Ok(result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromRoute]int id)
        {
            var result = await _studentRepository.DeleteStudentAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody]Student student)
        {
            var result = await _studentRepository.CreateStudentAsync(student);
            return Ok(result);
        }
    }
}
