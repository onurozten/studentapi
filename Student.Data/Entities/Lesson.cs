using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Student.Data.GenericRepository;

namespace Student.Data.Entities
{
    [Table("Lesson")]
    public class Lesson : IEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<LessonUserMap> ClassUserMaps { get; set; }
    }
}
