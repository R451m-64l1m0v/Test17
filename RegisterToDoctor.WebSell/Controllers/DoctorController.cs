using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.WebSell.Interfaces.IDTOs;
using RegisterToDoctor.WebSell.Interfaces.IServices;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Doctor;

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
            
                return Ok($"Status created: {doctorResponse.IsSuccess} doctorId: {doctorResponse.Result.Id}.");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: добавления доктора- {e.Message}.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDoctorInDto updateDoctor)
        {
            try
            {
                var doctorResponse = await _doctorService.Update(updateDoctor);

                if (doctorResponse.Result.Id == null)
                {
                    return NotFound();
                }

                return Ok($"Status updated: {doctorResponse.IsSuccess} doctorId: {doctorResponse.Result.Id}.");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: - {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var doctorResponse = await _doctorService.GetById(id);
                
                if (doctorResponse == null)
                {
                    return NotFound();
                }
                
                return Ok(doctorResponse.Result);
                
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: - {e.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorByFilterOutDto>>> GetDoctorsByFilter(
            DoctorByFilterInDto doctorByFilterRequest)         
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var isSecceed = await _doctorService.Delete(id);

                if (isSecceed == null)
                {
                    return NotFound();
                }

                return Ok($"Доктор удален");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: удаления доктора - {e.Message}");
            }

        }
    }


}

