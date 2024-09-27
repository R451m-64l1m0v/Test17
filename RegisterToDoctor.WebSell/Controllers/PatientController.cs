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
                var patientResponse = await _patientService.Create(createPatient);
                
                return Ok($"Status created: {patientResponse.IsSuccess}  PatientId: {patientResponse.Result.Id}.");                
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
                var patientResponse = await _patientService.Update(updatePatient);

                if (patientResponse == null)
                {
                    return NotFound();
                }                                

                return Ok($"Status updated: {patientResponse.IsSuccess}  PatientId: {patientResponse.Result.Id}.");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: - {e.Message}");
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid patientId)
        {
            try
            {
                var patientResponse = await _patientService.GetById(patientId);

                if (patientResponse == null)
                {
                    return NotFound();
                }

                return Ok(patientResponse);

            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: - {e.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PatienByFilterOutDto>>> GetPatientByFilter(
            PatientByFilterInDto patientByFilter)
        {
            try
            {
                var patientsResponse = await _patientService.GetPatientByFilter(patientByFilter);

                return Ok(patientsResponse);
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

                return Ok($"Пациет удален {result.Result.IsSecceed}");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка: удаления пациента- {e.Message}");
            }
        }
    }
}
