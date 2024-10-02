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
                var result = await _doctorService.Create(createDoctor);              

                return Ok($"Status created: {(result.IsSuccess ? $"successfully. DoctorId: {result.Result.Id}" : "unsuccessfully.")}");
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
                var result = await _doctorService.Update(updateDoctor);

                if (result.Result.Id == null)
                {
                    return NotFound();
                }

                return Ok($"Status updated: {(result.IsSuccess ? $"successfully. DoctorId: {result.Result.Id}" : "unsuccessfully.")}");
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
                var result = await _doctorService.GetById(id);
                
                if (result.Result == null)
                {
                    return NotFound();
                }
                
                return Ok(result.Result);
                
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: - {e.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<GetDoctorFindByFilterOutDto>>> GetDoctorsByFilter(
            [FromQuery] GetDoctorFindByFilterInDto getDoctorFindByFilterInDto)         
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsByFilter(getDoctorFindByFilterInDto);
                
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
                var result = await _doctorService.Delete(id);

                if (result.Result == null)
                {
                    return NotFound();
                }

                return Ok($"Status updated: {(result.IsSuccess ? "successfully." : "unsuccessfully.")}");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: удаления доктора - {e.Message}");
            }

        }
    }
}