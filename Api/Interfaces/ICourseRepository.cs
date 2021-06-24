using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Entities;

namespace Api.Interfaces
{
    public interface ICourseRepository
    {
        Task AddAsync(Course course);
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> GetCourseByCourseNumAsync(int courseNum);
        Task<Course> GetCourseByIdAsync(int id);
        void Update(Course course);
        Task<bool> SavAllChangesAsync();
    }
}