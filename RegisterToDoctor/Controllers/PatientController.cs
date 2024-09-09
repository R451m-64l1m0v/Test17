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
        public IActionResult Create(CreatePatientRequest createPatient)
        {
            try
            {
                var isSecceed = _patientService.Create(createPatient);

                if (isSecceed.Exception != null)
                {
                    return BadRequest($"Ошибка добавления доктора- {isSecceed.Exception}");
                }

                return Ok($"Пациент добавлен {isSecceed}");

                throw new Exception();
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка добавления пациента- {e.Message}");
            }
        }

        [HttpPut]
        public IActionResult Update(UpdatePatientRequest updatePatient)
        {
            try
            {
                var isSecceed = _patientService.Update(updatePatient);

                if (isSecceed == null)
                {
                    return NotFound();
                }

                if (isSecceed.Exception != null)
                {
                    return BadRequest($"Ошибка - {isSecceed.Exception}");
                }                

                return Ok($"Пациент обновлен {isSecceed}");

                throw new Exception();
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
                var doctor = await _patientService.GetById(patientId);

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
        public async Task<ActionResult<List<PatienByFilterResponse>>> GetPatientByFilter(
            PatientByFilterRequest patientByFilter)
        {
            try
            {
                var doctors = await _patientService.GetPatientByFilter(patientByFilter);

                return Ok(doctors);
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка - {e.Message}");
            }

        }
    }
}
