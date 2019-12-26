using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Lesson> GetCoolestCategory()
        {
            return await GetAll()
                .OrderByDescending(x=>x.Id)
                .FirstOrDefaultAsync();
        }
    }
}
