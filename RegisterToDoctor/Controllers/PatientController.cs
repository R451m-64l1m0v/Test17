using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Patient.Request;

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
