using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.WebSell.Interfaces.IServices;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Patient;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Patient;

namespace RegisterToDoctor.WebSell.Controllers
{
    [ApiController]
    [Route("patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Добавляет доктора
        /// </summary>        
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientInDto createPatient)
        {
            try
            {
                var result = await _patientService.Create(createPatient);

                return Ok($"Status created: {(result.IsSuccess ? $"successfully. PatientId: {result.Result.Id}" : "unsuccessfully.")}");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: добавления пациента- {e.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePatientInDto updatePatient)
        {
            try
            {
                var result = await _patientService.Update(updatePatient);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok($"Status updated: {(result.IsSuccess ? $"successfully. PatientId: {result.Result.Id}" : "unsuccessfully.")}");
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
                var result = await _patientService.GetById(id);

                if (result.Result == null)
                {
                    return NotFound();
                }

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: - {e.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPatienFindByFilterOutDto>>> GetPatientByFilter(
            GetPatientFindByFilterInDto getPatientFindByFilterInDto)
        {
            try
            {
                var result = await _patientService.GetPatientByFilter(getPatientFindByFilterInDto);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: - {e.Message}");
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid patientId)
        {
            try
            {
                var result = await _patientService.Delete(patientId);

                if (result.Result == null)
                {
                    return NotFound();
                }

                return Ok($"Status updated: {(result.IsSuccess ? "successfully." : "unsuccessfully.")}");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: удаления пациента- {e.Message}");
            }
        }
    }
}
