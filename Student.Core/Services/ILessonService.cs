using System.Collections.Generic;
using System.Threading.Tasks;
using Student.Core.Models.Lesson;

namespace Student.Core.Services
{
    public interface ILessonService
    {
        Task<List<StudentExamListModel>> GetLessonsWithExams (int userId);
    }
}