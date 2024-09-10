using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Helpers;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;
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

        public PatientService(IUnitOfWork uow,
            IPlotService plotService)
        {
            _patientRepository = uow.DbRepository<Patient>();
            _plotService = plotService;
        }

        public async Task<CreatePatientResponse> Create(CreatePatientRequest createPatient)
        {
            try
            {
                var plot = await _plotService.CheckPlot(createPatient.NumberPlot);

                if (createPatient.DateOfBirth <= maxAge || createPatient.DateOfBirth >= minAge)
                    throw new ArgumentException($"Ошибка дата рождения {createPatient.DateOfBirth.ToString("dd/MM/yyyy")} не коректна");

                if (string.IsNullOrWhiteSpace(createPatient.FirstName) ||
                        string.IsNullOrWhiteSpace(createPatient.LastName))
                    throw new ArgumentException($"Ошибка не заполнены поля Фамилии или Имени");

                if (string.IsNullOrWhiteSpace(createPatient.MiddleName))
                {
                    createPatient.MiddleName = null;
                }

                if (string.IsNullOrWhiteSpace(createPatient.Address))
                {
                    createPatient.Address = null;
                }

                var patient = new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = createPatient.FirstName,
                    LastName = createPatient.LastName,
                    MiddleName = createPatient.MiddleName,
                    DateOfBirth = createPatient.DateOfBirth,
                    Address = createPatient.Address,
                    Gender = createPatient.Gender,
                    PlotId = plot.Id,
                };

                _patientRepository.Create(patient);

                return new CreatePatientResponse { IsSecceed = true };
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

                return PatientByIdResponse.Create(patient);
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

                var isSortField = PatientHelper.CheckingSortingField(patientByFilterRequest.SortField);

                if (!isSortField)
                {
                    throw new ArgumentException($"Ошибка поля {patientByFilterRequest.SortField} не найдено");
                }

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

                return patients.Select(PatienByFilterResponse.Create);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<UpdatePatientResponse> Update(UpdatePatientRequest updatePatient)
        {
            try
            {
                if (updatePatient.Id == Guid.Empty)
                {
                    throw new ArgumentException($"Ошибка id пациента не может быть {updatePatient.Id}");
                }

                var plot = await _plotService.CheckPlot(updatePatient.NumberPlot);

                if (updatePatient.DateOfBirth <= maxAge || updatePatient.DateOfBirth >= minAge)
                    throw new ArgumentException($"Ошибка дата рождения {updatePatient.DateOfBirth.ToString("dd/MM/yyyy")} не коректна");

                if (string.IsNullOrWhiteSpace(updatePatient.FirstName) ||
                            string.IsNullOrWhiteSpace(updatePatient.LastName))
                    throw new ArgumentException($"Ошибка не заполнены поля Фамилии или Имени");

                if (string.IsNullOrWhiteSpace(updatePatient.MiddleName))
                {
                    updatePatient.MiddleName = null;
                }

                if (string.IsNullOrWhiteSpace(updatePatient.Address))
                {
                    updatePatient.Address = null;
                }

                var patient = _patientRepository.GetById(updatePatient.Id);

                if (patient != null)
                {
                    patient.FirstName = updatePatient.FirstName;
                    patient.LastName = updatePatient.LastName;
                    patient.MiddleName = updatePatient.MiddleName;
                    patient.Address = updatePatient.Address;
                    patient.DateOfBirth = updatePatient.DateOfBirth;
                    patient.Gender = updatePatient.Gender;
                    patient.PlotId = plot.Id;
                }
                else
                    return null;

                _patientRepository.Update(patient);

                return new UpdatePatientResponse { IsSecceed = true };
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
