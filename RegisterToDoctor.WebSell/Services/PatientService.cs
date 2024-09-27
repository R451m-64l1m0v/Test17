using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Domain.Entities;
using RegisterToDoctor.Infrastructure.Abstractions;
using RegisterToDoctor.Infrastructure.Implementations;
using RegisterToDoctor.WebSell.Exceptions;
using RegisterToDoctor.WebSell.Helpers.Patient;
using RegisterToDoctor.WebSell.Interfaces;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient;
using RegisterToDoctor.WebSell.Interfaces.IServices;
using RegisterToDoctor.WebSell.Interfaces.Markers;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Patient;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Patient;
using RegisterToDoctor.WebSell.Validators;
using RegisterToDoctor.WebSell.Validators.PatientValidators;
using System.Linq.Expressions;
using RegisterToDoctor.Infrastructure.DataAccessLayer.Interfaces;
using RegisterToDoctor.WebSell.Mapping;

namespace RegisterToDoctor.WebSell.Services
{
    public class PatientService : IPatientService, IScopedServiceMarker
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

        public async Task<ISuccessResult<CreatePatientOutDto>> Create(ICreatePatientInDto createPatientRequest)
        {
            try
            {
                await _createPatientValidator.ValidateAndThrowAsync(createPatientRequest);
                                
                var plot = await _plotService.CheckPlot(createPatientRequest.NumberPlot);

                ICreatePatient createPatient = CreatorPatient.Create(createPatientRequest, plot.Id);
                var patient = СreatorPatientHelper.Create(createPatient);

                await _patientRepository.CreateAsync(patient);

                return SuccessResultCreator.Create(true, CreatePatientOutDto.CreateResponse(patient));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISuccessResult<PatientByIdOutDto>> GetById(Guid patientId)
        {
            try
            {
                await _guidValidator.ValidateAndThrowAsync(patientId);
                
                var patient = await _patientRepository.GetByIdAsync(patientId);

                if (patient == null)
                {
                    throw new NotFoundException($"Ошибка: Пациент с ID {patientId} не найден.");
                }

                return SuccessResultCreator.Create(PatientByIdOutDto.CreateResponse(patient));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISuccessResult<IEnumerable<PatienByFilterOutDto>>> GetPatientByFilter(IPatientByFilterInDto patientByFilterRequest)
        {
            try
            {
                await _patientByFilterValidator.ValidateAndThrowAsync(patientByFilterRequest);

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
                
                return SuccessResultCreator.Create(patients.Select(PatienByFilterOutDto.CreateResponse));
            }
            catch (Exception)
            {
                throw;
            }
        }       

        public async Task<ISuccessResult<UpdatePatientOutDto>> Update(IUpdatePatientInDto updatePatientRequest)
        {
            try
            {
                await _updatePatientValidator.ValidateAndThrowAsync(updatePatientRequest);

                var patient = await _patientRepository.GetByIdAsync(updatePatientRequest.Id);

                if (patient == null)
                {
                    throw new NotFoundException($"Ошибка: Пациент с ID {updatePatientRequest.Id} не найден.");
                }

                var plot = await _plotService.CheckPlot(updatePatientRequest.NumberPlot);

                ICreatePatient updatePatient = UpdaterPatient.Create(updatePatientRequest, plot.Id);

                patient = UpdaterPatientHelper.Update(patient, updatePatient);

                await _patientRepository.UpdateAsync(patient);

                return SuccessResultCreator.Create(true, UpdatePatientOutDto.CreateResponse(patient));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISuccessResult<DeleteOutDto>> Delete(Guid patientId)
        {
            try
            {
                await _guidValidator.ValidateAndThrowAsync(patientId);
                
                var patient = await _patientRepository.GetByIdAsync(patientId);

                if (patient == null)
                {
                    throw new NotFoundException($"Ошибка: Пациент с ID {patientId} не найден.");
                }

                await _patientRepository.DeleteAsync(patient);

                return SuccessResultCreator.Create(true, DeleteOutDto.CreateResponse(true));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}