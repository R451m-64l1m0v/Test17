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
using RegisterToDoctor.WebSell.Helpers.Doctor;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor;

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

        /// <summary>
        /// Статус операции
        /// </summary>
        private bool IsSuccess { get; set; }

        public async Task<ISuccessResult<CreatePatientOutDto>> Create(ICreatePatientInDto createDoctorInDto)
        {
            try
            {
                await _createPatientValidator.ValidateAndThrowAsync(createDoctorInDto);

                var plot = await _plotService.CheckPlot(createDoctorInDto.NumberPlot);

                ICreatePatient createPatient = CreatorPatient.Create(createDoctorInDto, plot.Id);
                var patient = СreatorPatientHelper.Create(createPatient);

                await _patientRepository.CreateAsync(patient);

                return SuccessResultCreator.Create(IsSuccess = true, CreatePatientOutDto.Create(patient));
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

                return SuccessResultCreator.Create(PatientByIdOutDto.Create(patient));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISuccessResult<IEnumerable<GetPatienFindByFilterOutDto>>> GetPatientByFilter(IGetPatientFindByFilterInDto getPatientFindByFilterInDto)
        {
            try
            {
                await _patientByFilterValidator.ValidateAndThrowAsync(getPatientFindByFilterInDto);
                
                var patients = _patientRepository.Entity
                    .Include(x => x.Plot)
                    .AsNoTracking()
                    .TagWith("This is my spatial query")
                    .AsQueryable();

                patients = SorterUtility.PatientSorting(patients, getPatientFindByFilterInDto);

                patients = patients
                .Skip((getPatientFindByFilterInDto.PageNumber - 1) * getPatientFindByFilterInDto.PageSize)
                    .Take(getPatientFindByFilterInDto.PageSize);
                
                return SuccessResultCreator.Create(patients.Select(GetPatienFindByFilterOutDto.Create));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISuccessResult<UpdatePatientOutDto>> Update(IUpdatePatientInDto updateDoctorInDto)
        {
            try
            {
                await _updatePatientValidator.ValidateAndThrowAsync(updateDoctorInDto);

                var patient = await _patientRepository.GetByIdAsync(updateDoctorInDto.Id);

                if (patient == null)
                {
                    throw new NotFoundException($"Ошибка: Пациент с ID {updateDoctorInDto.Id} не найден.");
                }

                var plot = await _plotService.CheckPlot(updateDoctorInDto.NumberPlot);

                ICreatePatient updatePatient = UpdaterPatient.Create(updateDoctorInDto, plot.Id);

                patient = UpdaterPatientHelper.Update(patient, updatePatient);

                await _patientRepository.UpdateAsync(patient);

                return SuccessResultCreator.Create(IsSuccess = true, UpdatePatientOutDto.Create(patient));
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

                return SuccessResultCreator.Create(IsSuccess = true, DeleteOutDto.Create(true));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}