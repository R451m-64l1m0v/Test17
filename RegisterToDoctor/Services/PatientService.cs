using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;
using RegisterToDoctor.Models.Patient.Request;
using RegisterToDoctor.Models.Patient.Response;

namespace RegisterToDoctor.Services
{
    [RegisrationMarker(ServiceLifetime.Scoped)]
    public class PatientService : IPatientService
    {
        private readonly IDbRepository<Patient> _patientRepository;
        private readonly IPlotService _plotService;

        DateTime maxAge = new DateTime(1900, 1, 1);
        DateTime minAge = DateTime.Today.AddDays(1);

        public PatientService(IUnitOfWork uow,
            IPlotService plotService)
        {
            _patientRepository = uow.DbRepository<Patient>();
            _plotService = plotService;
        }

        public async Task<CreatePatientResponse> Create(CreatePatientRequest createPatient)
        {


            var plot = await _plotService.CheckPlot(createPatient.NumberPlot);
            
            if (createPatient.DateOfBirth <= maxAge || createPatient.DateOfBirth >= minAge)
                throw new ArgumentException($"Ошибка дата рождения {createPatient.DateOfBirth?.ToString("dd/MM/yyyy")} не коректна");

            if (string.IsNullOrWhiteSpace(createPatient.FirstName) ||
                    string.IsNullOrWhiteSpace(createPatient.LastName))
                throw new ArgumentException($"Ошибка не заполнены поля Фамилии или Имени");

            if (string.IsNullOrWhiteSpace(createPatient.MiddleName))
            {
                createPatient.MiddleName = null;
            }

            if (string.IsNullOrWhiteSpace(createPatient.Address))
            {
                createPatient.MiddleName = null;
            }

            var doctor = new Patient
            {
                Id = Guid.NewGuid(),
                FirstName = createPatient.FirstName,
                LastName = createPatient.LastName,
                MiddleName = createPatient.MiddleName,
                DateOfBirth = createPatient.DateOfBirth,
                Address = createPatient.Address,
            };

            _patientRepository.Create(doctor);

            return new CreatePatientResponse { IsSecceed = true };

            throw new NotImplementedException();
        }
    }
}
