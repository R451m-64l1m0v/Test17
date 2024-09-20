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
using RegisterToDoctor.Validators;
using System.Drawing;
using System;
using System.Linq.Expressions;
using System.Numerics;
using RegisterToDoctor.Сonstants;

namespace RegisterToDoctor.Services
{
    [RegisrationMarker(ServiceLifetime.Scoped)]
    public class PatientService : IPatientService
    {
        private readonly IDbRepository<Patient> _patientRepository;
        private readonly IPlotService _plotService;
        
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
                if (createPatientRequest.DateOfBirth <= ConstansForValidators.maxAge || createPatientRequest.DateOfBirth >= ConstansForValidators.minAge)
                    throw new ArgumentException($"Ошибка: дата рождения {createPatientRequest.DateOfBirth.ToString("dd/MM/yyyy")} не коректна.");

                UserEntityValidator.CheckFullNames(createPatientRequest.FirstName, createPatientRequest.LastName, createPatientRequest.MiddleName);

                if (createPatientRequest.OmsNumber.Length != ConstansForValidators.OmsLength)
                {
                    throw new ArgumentException($"Ошибка: в OmsNumber дожно быть 16 чисел.");
                }

                if (!createPatientRequest.OmsNumber.All(char.IsDigit))
                {
                    throw new ArgumentException($"Ошибка: в OmsNumber должно содержать только чисела.");
                }
                
                var plot = await _plotService.CheckPlot(createPatientRequest.NumberPlot);

                ICreatePatient createPatient = CreatorPatient.Create(createPatientRequest, plot.Id);

                var patient = СreatorPatientHelper.Create(createPatient);

                await _patientRepository.CreateAsync(patient);

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
                    throw new ArgumentException($"Ошибка: id пациента не может быть {patientId}.");
                }

                var patient = await _patientRepository.GetByIdAsync(patientId);

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
                //ToDo вынести проверки
                if (patientByFilterRequest.PageNumber <= 0)
                    throw new ArgumentException($"Ошибка: {nameof(patientByFilterRequest.PageNumber)} не может быть ноль или отрицательным.");

                if (patientByFilterRequest.PageSizeMin < 0 || patientByFilterRequest.PageSizeMax < patientByFilterRequest.PageSizeMin)
                    throw new ArgumentException($"Ошибка: поля {nameof(patientByFilterRequest.PageSizeMax)} или {patientByFilterRequest.PageSizeMin} заполнено некорректно.");

                if (patientByFilterRequest.PageSizeMax > ConstansForValidators.PageSizeLimit)
                {
                    throw new ArgumentException($"Ошибка: поле {nameof(patientByFilterRequest.PageSizeMax)} не может превышать {ConstansForValidators.PageSizeLimit} на странице.");
                }

                var pageSize = patientByFilterRequest.PageSizeMax - patientByFilterRequest.PageSizeMin;

                var patients = _patientRepository.Entity
                    .Include(x => x.Plot)
                    .AsNoTracking()
                    .TagWith("This is my spatial query")
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
                    .Skip((patientByFilterRequest.PageNumber - 1) * pageSize)
                    .Take(pageSize);

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
                //ToDo вынести проверки
                if (updatePatientRequest.Id == Guid.Empty)
                {
                    throw new ArgumentException($"Ошибка: id пациента не может быть {updatePatientRequest.Id}.");
                }

                if (updatePatientRequest.DateOfBirth <= ConstansForValidators.maxAge || updatePatientRequest.DateOfBirth >= ConstansForValidators.minAge)
                    throw new ArgumentException($"Ошибка: дата рождения {updatePatientRequest.DateOfBirth.ToString("dd/MM/yyyy")} не коректна.");

                UserEntityValidator.CheckFullNames(updatePatientRequest.FirstName, updatePatientRequest.LastName, updatePatientRequest.MiddleName);

                if (updatePatientRequest.OmsNumber.Length != ConstansForValidators.OmsLength)
                {
                    throw new ArgumentException($"Ошибка: в OmsNumber дожно быть 16 чисел.");
                }

                if (!updatePatientRequest.OmsNumber.All(char.IsDigit))
                {
                    throw new ArgumentException($"Ошибка: в OmsNumber должно содержать только чисела.");
                }
                
                var patient = await _patientRepository.GetByIdAsync(updatePatientRequest.Id);

                if (patient == null)
                {
                    return null;
                }

                var plot = await _plotService.CheckPlot(updatePatientRequest.NumberPlot);

                ICreatePatient updatePatient = UpdaterPatient.Create(updatePatientRequest, plot.Id);

                patient = UpdaterPatientHelper.Update(patient, updatePatient);

                await _patientRepository.UpdateAsync(patient);

                return UpdatePatientResponse.CreateResponse(patient);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DeletePatientResponse> Delete(Guid patientId)
        {
            try
            {
                if (patientId == Guid.Empty)
                {
                    throw new ArgumentException($"Ошибка: id пациента не может быть {patientId}.");
                }

                var patient = await _patientRepository.GetByIdAsync(patientId);

                if (patient == null)
                {
                    return null;
                }

                await _patientRepository.DeleteAsync(patient);

                return new DeletePatientResponse { IsSecceed = true };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
