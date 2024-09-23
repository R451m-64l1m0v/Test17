using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Exceptions;
using RegisterToDoctor.Helpers.Patient;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Patient;
using RegisterToDoctor.Models.Patient.Request;
using RegisterToDoctor.Models.Patient.Response;
using RegisterToDoctor.Validators;
using RegisterToDoctor.Validators.PatientValidators;
using System.Linq.Expressions;

namespace RegisterToDoctor.Services
{
    [RegisrationMarker(ServiceLifetime.Scoped)]
    public class PatientService : IPatientService
    {
        private readonly IDbRepository<Patient> _patientRepository;
        private readonly IPlotService _plotService;
        private readonly CreatePatientValidator _createPatientValidator;
        private readonly GuidValidator _guidValidator;
        private readonly PatientByFilterValidator _patientByFilterValidator;
        private readonly UpdatePatientValidator _updatePatientValidator;

        public PatientService(IUnitOfWork uow,
            IPlotService plotService,
            CreatePatientValidator createPatientValidator,
            GuidValidator guidValidator,
            PatientByFilterValidator patientByFilterValidator,
            UpdatePatientValidator updatePatientValidator)
        {
            _patientRepository = uow.DbRepository<Patient>();
            _plotService = plotService;
            _createPatientValidator = createPatientValidator;
            _guidValidator = guidValidator;
            _patientByFilterValidator = patientByFilterValidator;
            _updatePatientValidator = updatePatientValidator;
        }

        public async Task<CreatePatientResponse> Create(CreatePatientRequest createPatientRequest)
        {
            try
            {
                _createPatientValidator.Validate(createPatientRequest);
                                
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
                var result = _guidValidator.Validate(patientId);

                if (!result.IsValid)
                {
                    throw new ArgumentException(result.Errors[0].ErrorMessage);
                }

                var patient = await _patientRepository.GetByIdAsync(patientId);

                if (patient == null)
                {
                    throw new NotFoundException($"Ошибка: Пациент с ID {patientId} не найден.");
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
                _patientByFilterValidator.Validate(patientByFilterRequest);

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
                _updatePatientValidator.Validate(updatePatientRequest);

                var patient = await _patientRepository.GetByIdAsync(updatePatientRequest.Id);

                if (patient == null)
                {
                    throw new NotFoundException($"Ошибка: Пациент с ID {updatePatientRequest.Id} не найден.");
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
                var result = _guidValidator.Validate(patientId);

                if (!result.IsValid)
                {
                    throw new ArgumentException(result.Errors[0].ErrorMessage);
                }

                var patient = await _patientRepository.GetByIdAsync(patientId);

                if (patient == null)
                {
                    throw new NotFoundException($"Ошибка: Пациент с ID {patientId} не найден.");
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
