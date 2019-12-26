using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Student.Core.Services;
using Student.Data.Entities;

namespace Student.Api.Controllers
{
    [Route("student")]
    [Authorize()]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILessonService _lessonService;

        public StudentController(SignInManager<User> signInManager, ILessonService lessonService)
        {
            _signInManager = signInManager;
            _lessonService = lessonService;
        }

        [HttpGet]
        [Route("lessons")]
        public async Task<IActionResult> Lessons()
        {
            var userId= Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var lessonsWithExam = await _lessonService.GetLessonsWithExams(userId);
            return Ok(lessonsWithExam);
        }


        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new {succ=true}); // boş Ok() gönderdiğinde jquery post success eventi tetiklenmiyor!
        }
    }
}
