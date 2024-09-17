using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Domen.Core.RequestModels.Interfaces;
using RegisterToDoctor.Helpers.Patient;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Infrastructure.Data.Migrations;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;
using RegisterToDoctor.Models.Patient;
using RegisterToDoctor.Models.Patient.Request;
using RegisterToDoctor.Models.Patient.Response;
using System.Linq.Expressions;
using System.Numerics;

namespace RegisterToDoctor.Services
{
    [RegisrationMarker(ServiceLifetime.Scoped)]
    public class PatientService : IPatientService
    {
        private readonly IDbRepository<Patient> _patientRepository;
        private readonly IPlotService _plotService;

        DateTime maxAge = new DateTime(1900, 1, 1);
        DateTime minAge = DateTime.Today.AddDays(1);
        int OmsLength = 16;

        public PatientService(IUnitOfWork uow,
            IPlotService plotService)
        {
            _patientRepository = uow.DbRepository<Patient>();
            _plotService = plotService;
        }

        public async Task<CreatePatientResponse> Create(CreatePatientRequest createPatientRequest)
        {
            try
            {
                //ToDo вынести проверки
                if (createPatientRequest.DateOfBirth <= maxAge || createPatientRequest.DateOfBirth >= minAge)
                    throw new ArgumentException($"Ошибка дата рождения {createPatientRequest.DateOfBirth.ToString("dd/MM/yyyy")} не коректна");

                if (string.IsNullOrWhiteSpace(createPatientRequest.FirstName) ||
                        string.IsNullOrWhiteSpace(createPatientRequest.LastName))
                    throw new ArgumentException($"Ошибка не заполнены поля Фамилии или Имени");

                if (createPatientRequest.OmsNumber.Length != OmsLength)
                {
                    throw new ArgumentException($"Ошибка в OmsNumber дожно быть 16 чисел");
                }

                if (!createPatientRequest.OmsNumber.All(char.IsDigit))
                {
                    throw new ArgumentException($"Ошибка в OmsNumber должно содержать только чисела");
                }

                if (string.IsNullOrWhiteSpace(createPatientRequest.MiddleName))
                {
                    createPatientRequest.MiddleName = null;
                }               

                var plot = await _plotService.CheckPlot(createPatientRequest.NumberPlot);

                ICreatePatient createPatient = CreatorPatient.Create(createPatientRequest, plot.Id);

                var patient = СreatorPatientHelper.Create(createPatient);

                _patientRepository.Create(patient);

                return CreatePatientResponse.CreateResponse(patient);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PatientByIdResponse> GetById(Guid patientId)
        {
            try
            {
                if (patientId == Guid.Empty)
                {
                    throw new ArgumentException($"Ошибка id пациента не может быть {patientId}");
                }

                var patient = _patientRepository.GetById(patientId);

                if (patient == null)
                {
                    return null;
                }

                return PatientByIdResponse.CreateResponse(patient);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PatienByFilterResponse>> GetPatientByFilter(PatientByFilterRequest patientByFilterRequest)
        {
            try
            {
                if (patientByFilterRequest.PageNumber == 0)
                    throw new ArgumentException($"Ошибка не указан {nameof(patientByFilterRequest.PageNumber)}");

                if (patientByFilterRequest.PageSize == 0)
                    throw new ArgumentException($"Ошибка не указан {nameof(patientByFilterRequest.PageSize)}");

                var patients = _patientRepository.Entity
                    .Include(x => x.Plot)
                    .AsQueryable();

                var sortField = patientByFilterRequest.SortField.ToString();

                var parameter = Expression.Parameter(typeof(Patient), "e");
                var property = Expression.Property(parameter, sortField);
                var conversion = Expression.Convert(property, typeof(object));
                var orderByExpression = Expression.Lambda<Func<Patient, object>>(conversion, parameter);

                if (patientByFilterRequest?.Ascending ?? false)
                {
                    patients = patients.OrderByDescending(orderByExpression);
                }
                else
                {
                    patients = patients.OrderBy(orderByExpression);
                }

                patients = patients
                    .Skip((patientByFilterRequest.PageNumber - 1) * patientByFilterRequest.PageSize)
                    .Take(patientByFilterRequest.PageSize);

                return patients.Select(PatienByFilterResponse.CreateResponse);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<UpdatePatientResponse> Update(UpdatePatientRequest updatePatientRequest)
        {
            try
            {
                if (updatePatientRequest.Id == Guid.Empty)
                {
                    throw new ArgumentException($"Ошибка id пациента не может быть {updatePatientRequest.Id}");
                }

                if (updatePatientRequest.DateOfBirth <= maxAge || updatePatientRequest.DateOfBirth >= minAge)
                    throw new ArgumentException($"Ошибка дата рождения {updatePatientRequest.DateOfBirth.ToString("dd/MM/yyyy")} не коректна");

                if (string.IsNullOrWhiteSpace(updatePatientRequest.FirstName) ||
                            string.IsNullOrWhiteSpace(updatePatientRequest.LastName))
                    throw new ArgumentException($"Ошибка не заполнены поля Фамилии или Имени");

                if (updatePatientRequest.OmsNumber.Length != OmsLength)
                {
                    throw new ArgumentException($"Ошибка в OmsNumber дожно быть 16 чисел");
                }

                if (!updatePatientRequest.OmsNumber.All(char.IsDigit))
                {
                    throw new ArgumentException($"Ошибка в OmsNumber должно содержать только чисела");
                }

                if (string.IsNullOrWhiteSpace(updatePatientRequest.MiddleName))
                {
                    updatePatientRequest.MiddleName = null;
                }                

                var patient = _patientRepository.GetById(updatePatientRequest.Id);

                if (patient == null)
                {
                    return null;
                }

                var plot = await _plotService.CheckPlot(updatePatientRequest.NumberPlot);

                ICreatePatient updatePatient = UpdaterPatient.Create(updatePatientRequest, plot.Id);

                patient = UpdaterPatientHelper.Update(patient, updatePatient);

                _patientRepository.Update(patient);

                return UpdatePatientResponse.CreateResponse(patient);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
