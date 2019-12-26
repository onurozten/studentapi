namespace Student.Core.Models.Lesson
{
    
    public class StudentExamListModel
    {
        public int LessonMapId { get; set; }
        public int LessonId { get; set; }
        public string Lesson { get; set; }
        public decimal? Exam1 { get; set; }
        public decimal? Exam2 { get; set; }
        public decimal? Exam3 { get; set; }
        public decimal? VerbalExam1 { get; set; }
        public decimal? VerbalExam2 { get; set; }
        public decimal Average { get; set; }
        public decimal GeneralAverage { get; set; }
        public decimal Last10 { get; set; }
    }
}
