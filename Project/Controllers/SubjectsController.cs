using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;
using Project.Dto;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsService _subjectsService;
        private readonly IWebHostEnvironment _env;

        public SubjectsController(ISubjectsService subjectsService, IWebHostEnvironment env)
        {
            _subjectsService = subjectsService;
            _env = env;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_subjectsService.GetAll().ConvertAll(t => t.ConvertToSubjectsDto()));
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
                return Ok(_subjectsService.GetById(id).ConvertToSubjectsDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(
            Subjects subjects)
        {
            try
            {
                _subjectsService.Create(subjects);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete( Subjects subjects)
        {
            try
            {
                _subjectsService.Delete(subjects);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Subjects subjects)
        {
            try
            {
                _subjectsService.Update(subjects);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SaveFile")]
        public IActionResult SaveFile()
        {
            try{
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
