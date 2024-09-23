using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.WebSell.Interfaces;
using RegisterToDoctor.WebSell.Models.Doctors.Request;
using RegisterToDoctor.WebSell.Models.Doctors.Response;
using RegisterToDoctor.WebSell.Models.DTOs;

namespace RegisterToDoctor.WebSell.Controllers
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
        public async Task<IActionResult> Create(CreateDoctorInDto createDoctor)
        {
            try
            {
                var doctorResponse = await _doctorService.Create(createDoctor);                
            
                return Ok($"Док добавлен doctorId {doctorResponse.Result}.");                
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: добавления доктора- {e.Message}.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDoctorRequest createDoctor)
        {
            try
            {
                var doctorId = await _doctorService.Update(createDoctor);

                if (doctorId == null)
                {
                    return NotFound();
                }                                               

                return Ok($"Док обновлен Id доктор {doctorId}");

                throw new Exception();
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: - {e.Message}");
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

                return Ok();
                
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: - {e.Message}");
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
                return BadRequest($"Ошибка: - {e.Message}");                
            }            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid doctorId)
        {
            try
            {
                var isSecceed = await _doctorService.Delete(doctorId);

                if (isSecceed == null)
                {
                    return NotFound();
                }

                return Ok($"Доктор удален {isSecceed.IsSecceed}");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: удаления доктора - {e.Message}");
            }

        }
    }


}

