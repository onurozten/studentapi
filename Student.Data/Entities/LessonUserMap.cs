using System.ComponentModel.DataAnnotations.Schema;
using Student.Data.GenericRepository;

namespace Student.Data.Entities
{
    [Table("LessonUserMap")]
    public class LessonUserMap : IEntity
    {
        public int Id { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual Lesson Lesson { get; set; }
        public int LessonId { get; set; }

        public decimal? Exam1 { get; set; }
        public decimal? Exam2 { get; set; }
        public decimal? Exam3 { get; set; }
        public decimal? VerbalExam1 { get; set; }
        public decimal? VerbalExam2 { get; set; }
        public decimal Average { get; set; }
    }
}
