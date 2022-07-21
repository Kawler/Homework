using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;
using Project.Dto;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IWebHostEnvironment _env;

        public TeacherController(ITeacherService teacherService, IWebHostEnvironment env)
        {
            _teacherService = teacherService;
            _env = env;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_teacherService.GetAll().ConvertAll(t => t.ConvertToTeacherDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_teacherService.GetById(id).ConvertToTeacherDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(
            Teacher teacher)
        {
            try
            {
                _teacherService.Create(teacher);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Teacher teacher)
        {
            try
            {
                _teacherService.Delete(teacher);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Teacher teacher)
        {
            try
            {
                _teacherService.Update(teacher);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("group")]
        public IActionResult GroupByTaughtSubject()
        {
            try
            {
                return Ok(_teacherService.GroupByTaughtSubject());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SaveFile")]
        public IActionResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
