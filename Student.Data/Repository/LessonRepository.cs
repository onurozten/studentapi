using Student.Data.Entities;
using Student.Data.GenericRepository;

namespace Student.Data.Repository
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(DataContext dbContext)
            : base(dbContext)
        {
            
        }

    }
}
