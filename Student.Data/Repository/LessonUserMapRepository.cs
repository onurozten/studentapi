using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student.Data.Entities;
using Student.Data.GenericRepository;

namespace Student.Data.Repository
{
    public class LessonUserMapRepository : GenericRepository<LessonUserMap>, ILessonUserMapRepository
    {
        public LessonUserMapRepository(DataContext dbContext)
            : base(dbContext)
        {
            
        }

    }
}
