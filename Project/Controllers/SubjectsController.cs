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

        public SubjectsController(ISubjectsService subjectsService)
        {
            _subjectsService = subjectsService;
            
        }

        [HttpGet]
        public JsonResult GetAll()
        {

            return new JsonResult(_subjectsService.GetAll().ConvertAll(t => t.ConvertToSubjectsDto()));

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
        public IActionResult Create(Subjects subjects)
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
        [Route("{id?}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _subjectsService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id?}")]
        public IActionResult Update( int id,Subjects subjects)
        {
            try
            {
                _subjectsService.Update(subjects,id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
