using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student.Core.Models.Lesson;
using Student.Data.Repository;

namespace Student.Core.Services
{
    public class LessonService  :ILessonService
    {
        private readonly ILessonUserMapRepository _lessonUserMapRepository;

        public LessonService(ILessonUserMapRepository lessonUserMapRepository)
        {
            _lessonUserMapRepository = lessonUserMapRepository;
        }


        public async Task<List<StudentExamListModel>> GetLessonsWithExams(int userId)
        {
            var generalAverages = await (from m in _lessonUserMapRepository.GetAll()
                group m by m.LessonId
                into g
                select new
                {
                    lessonId = g.Key,
                    ort = g.Average(x => x.Average),
                    sonOn = _lessonUserMapRepository.GetAll().Where(x=>x.LessonId==g.Key).OrderByDescending(x=>x.Average).Take(10).Select(x=>x.Average).LastOrDefault()
                }).ToListAsync();

            var lessons = await _lessonUserMapRepository.GetAll().Where(x => x.UserId == userId)
                .Select(x => new
                {
                    id=x.Id,
                    lessonId=x.Lesson.Id,
                    lesson=x.Lesson.Name,
                    y1=x.Exam1,
                    y2=x.Exam2,
                    y3=x.Exam3,
                    s1=x.VerbalExam1,
                    s2=x.VerbalExam2,
                    ort=x.Average,
                    genelOrt = 0,
                    sonOn=0,
                }).ToListAsync();

            var joined = (from l in lessons
                join g in generalAverages on l.lessonId equals g.lessonId
                select new StudentExamListModel
                {
                    LessonMapId= l.id,
                    LessonId= l.lessonId,
                    Lesson= l.lesson,
                    Exam1= l.y1,
                    Exam2= l.y2,
                    Exam3= l.y3,
                    VerbalExam1= l.s1,
                    VerbalExam2= l.s2,
                    Average = l.ort,
                    GeneralAverage = Math.Round(g.ort,2),
                    Last10 = Math.Round(g.sonOn,2)
                }).OrderBy(x=>x.Lesson).ToList();

            return joined;
        }
    }
}
