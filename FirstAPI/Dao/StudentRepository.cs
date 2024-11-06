using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Dao
{
    public class StudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResultObject<Student>> GetAllStudentsAsync()
        {
            return new ResultObject<Student>
            {
                StatusCode = 200,
                Values = await _dbContext.Students.ToListAsync()
            };
        }
        public async Task<ResultObject<Student>> GetStudentByIdAsync(int id)
        {
            return new ResultObject<Student>
            {
                StatusCode = 200,
                Value = await _dbContext.Students.FindAsync(id)
            };
        }
        public async Task<ResultObject<Student>> UpdateStudent(Student student)
        {
            var resultObj = await GetStudentByIdAsync(student.Id);
            resultObj.Value.NameSurname = student.NameSurname;
            resultObj.Value.PhoneNumber = student.PhoneNumber;

            await Task.Run(async () =>
             {
                 _dbContext.Students.Update(resultObj.Value);
             });
            await _dbContext.SaveChangesAsync();
            return new ResultObject<Student>
            {
                StatusCode = 200,
                Value = student
            };
        }
        public async Task<ResultObject<Student>> DeleteStudentAsync(int id)
        {
            var resultObj = await GetStudentByIdAsync(id);
            _dbContext.Students.Remove(resultObj.Value);
            await _dbContext.SaveChangesAsync();
            return new ResultObject<Student>
            {
                Message = $"{id} Nolu Kayıt Silinmiştir."
            };
        }
        public async Task<ResultObject<Student>> CreateStudentAsync(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return new()
            {
                Value = student,
                Message = $"{student.NameSurname} İsimli Öğrenci Başarıyla Oluşturuldu.",
                StatusCode = 201
            };

        }
    }
}
