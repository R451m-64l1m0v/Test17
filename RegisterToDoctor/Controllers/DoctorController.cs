using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Models.Doctors.Request;

namespace RegisterToDoctor.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : ControllerBase
    {
        /// <summary>
        /// Добавляет доктора
        /// </summary>        
        [HttpPost]
        public IActionResult Create(CreateDoctorRequest createDoctor)
        {
            try
            {
                
            
                return Ok("Док добавлен");
                
                throw new Exception();
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка добавления доктора- {e.Message}");
            }
        }

        
    }
}
