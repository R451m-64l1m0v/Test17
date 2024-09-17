using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;
using RegisterToDoctor.Models.Patient.Request;
using RegisterToDoctor.Models.Patient.Response;
using RegisterToDoctor.Services;

namespace RegisterToDoctor.Controllers
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
        public async Task<IActionResult> Create(CreatePatientRequest createPatient)
        {
            try
            {
                var patientResponse = await _patientService.Create(createPatient);
                
                return Ok($"Пациент добавлен Id пацииента {patientResponse.Id}.");                
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка добавления пациента- {e.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePatientRequest updatePatient)
        {
            try
            {
                var patientResponse = await _patientService.Update(updatePatient);

                if (patientResponse == null)
                {
                    return NotFound();
                }                                

                return Ok($"Пациент обновлен Id пациента {patientResponse.Id}.");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка - {e.Message}");
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
                return BadRequest($"Ошибка - {e.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PatienByFilterResponse>>> GetPatientByFilter(
            PatientByFilterRequest patientByFilter)
        {
            try
            {
                var patientsResponse = await _patientService.GetPatientByFilter(patientByFilter);

                return Ok(patientsResponse);
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка - {e.Message}");
            }

        }
    }
}
