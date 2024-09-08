using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;

namespace RegisterToDoctor.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        /// <summary>
        /// Добавляет доктора
        /// </summary>        
        [HttpPost]
        public IActionResult Create(CreateDoctorRequest createDoctor)
        {
            try
            {
                var isSecceed = _doctorService.Create(createDoctor);

                if (isSecceed.Exception != null)
                {
                    return BadRequest($"Ошибка добавления доктора- {isSecceed.Exception}");
                }
            
                return Ok("Док добавлен");
                
                throw new Exception();
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка добавления доктора- {e.Message}");
            }
        }

        [HttpPut]
        public IActionResult Update(UpdateDoctorRequest createDoctor)
        {
            try
            {
                var isSecceed = _doctorService.Update(createDoctor);

                if (isSecceed.Exception != null)
                {
                    return BadRequest($"Ошибка - {isSecceed.Exception}");
                }

                return Ok("Док добавлен");

                throw new Exception();
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка - {e.Message}");
            }
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid doctorId)
        {
            try
            {
                var doctor = await _doctorService.GetById(doctorId);

                if (doctor == null)
                {
                    return NotFound();
                }

                return Ok(doctor);
                
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка - {e.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorByFilterResponse>>> GetDoctorsByFilter(
            DoctorByFilterRequest doctorByFilterRequest)         
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsByFilter(doctorByFilterRequest);
                
                return Ok(doctors);
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка - {e.Message}");                
            }
            
        }
    }


}

