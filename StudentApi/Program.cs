using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Student.Data;
using Student.Data.Entities;

namespace Student.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = CreateHostBuilder(args);
            IHost host = hostBuilder.Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DataContext>();
                context.Database.EnsureCreated();

                //var lessonRepository = scope.ServiceProvider.GetService<ILessonRepository>();

                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

                if (!userManager.Users.Any())
                {
                    var c1 = new Lesson{Name = "TÜRKÇE"};
                    var c2 = new Lesson{Name = "MATEMATÝK"};
                    var c3 = new Lesson{Name = "FEN BÝLÝMLERÝ"};
                    
                    context.Lessons.Add(c1);
                    context.Lessons.Add(c2);
                    context.Lessons.Add(c3);
                    context.SaveChanges();

                    var user3 = new User
                    {
                        UserName = "onur",
                        Email = "onur301@gmail.com",
                        Firstname = "Onur",
                        Lastname = "ÖZTEN",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 87, Exam2 = 47, Exam3 = 37, VerbalExam1 = 97}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 30, Exam2 = 30, Exam3 = 55, VerbalExam1 = 20, VerbalExam2 = 30}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 85, Exam2 = 98, VerbalExam1 = 75})
                        }
                    };
                    var result = userManager.CreateAsync(user3, "123").Result;

                    var user2 = new User()
                    {
                        UserName = "ozan",
                        Email = "ozan@ozan.com",
                        Firstname = "Ozan",
                        Lastname = "ÖZTEN",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 90, Exam2 = 92, Exam3 = 90, VerbalExam1 = 95}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 70, Exam2 = 80, Exam3 = 75, VerbalExam1 = 100, VerbalExam2 = 100}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 100, Exam2 = 75, VerbalExam1 = 100})
                        }
                    };
                    result = userManager.CreateAsync(user2, "123").Result;

                    var user1 = new User()
                    {
                        UserName = "eren",
                        Email = "eren@eren.com",
                        Firstname = "Eren",
                        Lastname = "ÖZTEN",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 85, Exam2 = 90, Exam3 = 95, VerbalExam1 = 100}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 90, Exam2 = 90, Exam3 = 95, VerbalExam1 = 100, VerbalExam2 = 85}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 80, Exam2 = 85, VerbalExam1 = 100})
                        }
                    };
                    result=userManager.CreateAsync(user1, "123").Result;

                    var user4 = new User()
                    {
                        UserName = "hakan",
                        Email = "hakan@hakan.com",
                        Firstname = "Hakan",
                        Lastname = "ÖZYOL",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 70, Exam2 = 65, Exam3 = 96, VerbalExam1 = 90}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 50, Exam2 = 70, Exam3 = 65, VerbalExam1 = 60, VerbalExam2 = 40}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 55, Exam2 = 85, VerbalExam1 = 85})
                        }
                    };
                    result = userManager.CreateAsync(user4, "123").Result;

                    var user5 = new User()
                    {
                        UserName = "emre",
                        Email = "emre@emre.com",
                        Firstname = "Emre",
                        Lastname = "SELAMOÐLU",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 80, Exam2 = 75, Exam3 = 76, VerbalExam1 = 60}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 80, Exam2 = 70, Exam3 = 75, VerbalExam1 = 60, VerbalExam2 = 30}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 85, Exam2 = 75, VerbalExam1 = 95})
                        }
                    };
                    result = userManager.CreateAsync(user5, "123").Result;

                    var user6 = new User()
                    {
                        UserName = "sevda",
                        Email = "sevda@sevda.com",
                        Firstname = "Sevda",
                        Lastname = "AYDOÐDU",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 90, Exam2 = 85, Exam3 = 72, VerbalExam1 = 70}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 90, Exam2 = 80, Exam3 = 70, VerbalExam1 = 70, VerbalExam2 = 60}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 95, Exam2 = 85, VerbalExam1 = 90})
                        }
                    };
                    result = userManager.CreateAsync(user6, "123").Result;

                    var user7 = new User()
                    {
                        UserName = "mehtap",
                        Email = "mehtap@mehtap.com",
                        Firstname = "Mehtap",
                        Lastname = "GÜNER",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 50, Exam2 = 55, Exam3 = 62, VerbalExam1 = 60}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 60, Exam2 = 40, Exam3 = 50, VerbalExam1 = 60, VerbalExam2 = 70}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 75, Exam2 = 60, VerbalExam1 = 30})
                        }
                    };
                    result = userManager.CreateAsync(user7, "123").Result;

                    var user8 = new User()
                    {
                        UserName = "gokhan",
                        Email = "gokhan@gokhan.com",
                        Firstname = "Gökhan",
                        Lastname = "AYDOÐAN",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 60, Exam2 = 45, Exam3 = 90, VerbalExam1 = 40}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 70, Exam2 = 50, Exam3 = 40, VerbalExam1 = 50, VerbalExam2 = 90}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 85, Exam2 = 70, VerbalExam1 = 60})
                        }
                    };
                    result = userManager.CreateAsync(user8, "123").Result;

                    var user9 = new User()
                    {
                        UserName = "selim",
                        Email = "selim@selim.com",
                        Firstname = "Selim",
                        Lastname = "IÞIK",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 65, Exam2 = 95, Exam3 = 50, VerbalExam1 = 40}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 79, Exam2 = 90, Exam3 = 50, VerbalExam1 = 50, VerbalExam2 = 50}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 80, Exam2 = 90, VerbalExam1 = 90})
                        }
                    };
                    result = userManager.CreateAsync(user9, "123").Result;

                    var user10 = new User()
                    {
                        UserName = "lale",
                        Email = "lale@lale.com",
                        Firstname = "Lale",
                        Lastname = "SEVÝNÇ",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 45, Exam2 = 90, Exam3 = 50, VerbalExam1 = 40}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 49, Exam2 = 90, Exam3 = 50, VerbalExam1 = 50, VerbalExam2 = 50}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 40, Exam2 = 90, VerbalExam1 = 90})
                        }
                    };
                    result = userManager.CreateAsync(user10, "123").Result;

                    var user11 = new User()
                    {
                        UserName = "ezgi",
                        Email = "ezgi@ezgi.com",
                        Firstname = "Ezgi",
                        Lastname = "ADIGÜZEL",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 75, Exam2 = 80, Exam3 = 60, VerbalExam1 = 90}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 79, Exam2 = 80, Exam3 = 60, VerbalExam1 = 80, VerbalExam2 = 86}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 70, Exam2 = 80, VerbalExam1 = 100})
                        }
                    };
                    result = userManager.CreateAsync(user11, "123").Result;

                    
                    var user12 = new User()
                    {
                        UserName = "ebru",
                        Email = "ebru@ebru.com",
                        Firstname = "Ebru",
                        Lastname = "ADIGÜZEL",
                        ClassUserMaps = new List<LessonUserMap>()
                        {
                            OrtalamaHesap(new LessonUserMap(){Lesson = c1, Exam1 = 65, Exam2 = 70, Exam3 = 80, VerbalExam1 = 48}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c2, Exam1 = 69, Exam2 = 70, Exam3 = 80, VerbalExam1 = 58, VerbalExam2 = 59}),
                            OrtalamaHesap(new LessonUserMap(){Lesson = c3, Exam1 = 60, Exam2 = 96, VerbalExam1 = 90})
                        }
                    };
                    result = userManager.CreateAsync(user12, "123").Result;
                }
            }

            host.Run();

        }

        static LessonUserMap OrtalamaHesap(LessonUserMap lesson)
        {
            var yaziliSayi = !lesson.Exam3.HasValue ? 2 : 3;
            var sozluSayi = !lesson.VerbalExam2.HasValue ? 1 : 2;
            var yaziliOrt = (lesson.Exam1 + lesson.Exam2 + (lesson.Exam3 ?? 0)) / yaziliSayi;
            var ort = (yaziliOrt + lesson.VerbalExam1 + (lesson.VerbalExam2 ?? 0)) / (sozluSayi+1);
            lesson.Average = (decimal)ort;
            return lesson;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
