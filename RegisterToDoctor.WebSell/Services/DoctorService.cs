using System.Linq.Expressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Domain.Entities;
using RegisterToDoctor.Infrastructure.Abstractions;
using RegisterToDoctor.Infrastructure.DataAccessLayer.Interfaces;
using RegisterToDoctor.Infrastructure.Implementations;
using RegisterToDoctor.WebSell.Attributes;
using RegisterToDoctor.WebSell.Exceptions;
using RegisterToDoctor.WebSell.Helpers.Doctor;
using RegisterToDoctor.WebSell.Interfaces;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;
using RegisterToDoctor.WebSell.Interfaces.IServices;
using RegisterToDoctor.WebSell.Interfaces.Markers;
using RegisterToDoctor.WebSell.Mapping;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Doctor;
using RegisterToDoctor.WebSell.Validators;
using RegisterToDoctor.WebSell.Validators.DoctorValidators;

namespace RegisterToDoctor.WebSell.Services
{
    public class DoctorService : IDoctorService, IScopedServiceMarker
    {
        private readonly IDbRepository<Doctor> _docRepository;
        private readonly ISpecializationService _specializationService;
        private readonly IOfficeService _officeService;
        private readonly IPlotService _plotService;
        private readonly CreateDoctorValidator _createDoctorValidator;
        private readonly GuidValidator _guidValidator;
        private readonly DoctorByFilterValidator _doctorByFilterValidator;
        private readonly UpdateDoctorValidator _updateDoctorValidator;

        public DoctorService(IUnitOfWork uow,
            ISpecializationService specializationService,
            IOfficeService officeService,
            IPlotService plotService,
            CreateDoctorValidator createDoctorValidator,
            GuidValidator guidValidator,
            DoctorByFilterValidator doctorByFilterValidator,
            UpdateDoctorValidator updateDoctorValidator)
        {
            _docRepository = uow.DbRepository<Doctor>();
            _specializationService = specializationService;
            _officeService = officeService;
            _plotService = plotService;
            _createDoctorValidator = createDoctorValidator;
            _guidValidator = guidValidator;
            _doctorByFilterValidator = doctorByFilterValidator;
            _updateDoctorValidator = updateDoctorValidator;
        }

        public async Task<ISuccessResult<CreateDoctorOutDto>> Create(ICreateDoctorInDto createDoctorRequest)
        {
            try
            {
                await _createDoctorValidator.ValidateAndThrowAsync(createDoctorRequest);
                                
                var specializationTask = _specializationService.CheckSpecialization(createDoctorRequest.Specialization);

                var officeTask = _officeService.CheckOffice(createDoctorRequest.NumberOffice);

                var plotTask = _plotService.CheckPlot(createDoctorRequest.NumberPlot);

                await Task.WhenAll(specializationTask, officeTask, plotTask);

                var specialization = specializationTask.Result;
                var office = officeTask.Result;
                var plot = plotTask.Result;

                //todo: autoMapper
                ICreateDoctor createDoctor = CreatorDoctor.Create(createDoctorRequest, specialization.Id, office.Id, plot.Id);

                var doctor = СreatorDoctorHelper.Create(createDoctor);
                
                await _docRepository.CreateAsync(doctor);

                return SuccessResultCreator.Create( true, CreateDoctorOutDto.CreateResponse(doctor)); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISuccessResult<DoctorByIdOutDto>> GetById(Guid doctorId)
        {
            try
            {
                await _guidValidator.ValidateAndThrowAsync(doctorId);

                var doctor = await _docRepository.GetByIdAsync(doctorId);

                if (doctor == null)
                {
                    throw new NotFoundException($"Ошибка: Доктор с ID {doctorId} не найден.");
                }

                return SuccessResultCreator.Create(DoctorByIdOutDto.CreateResponse(doctor));                  
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISuccessResult<IEnumerable<DoctorByFilterOutDto>>> GetDoctorsByFilter(IDoctorByFilterInDto doctorByFilterRequest)
        {
            try
            {
                await _doctorByFilterValidator.ValidateAndThrowAsync(doctorByFilterRequest); //Validate(doctorByFilterRequest);
                
                var pageSize = doctorByFilterRequest.PageSizeMax - doctorByFilterRequest.PageSizeMin;

                var doctors = _docRepository.Entity
                    .Include(x => x.Office)
                    .Include(x => x.Specialization)
                    .Include(x => x.Plot)
                    .AsNoTracking()
                    .TagWith("This is my spatial query")
                    .AsQueryable();

                var sortField = doctorByFilterRequest.SortField.ToString();

                var parameter = Expression.Parameter(typeof(Doctor), "e");
                var property = Expression.Property(parameter, sortField);
                var conversion = Expression.Convert(property, typeof(object));
                var orderByExpression = Expression.Lambda<Func<Doctor, object>>(conversion, parameter);

                if (doctorByFilterRequest?.Ascending ?? false)
                {
                    doctors = doctors.OrderByDescending(orderByExpression);
                }
                else
                {
                    doctors = doctors.OrderBy(orderByExpression);
                }

                doctors = doctors
                    .Skip((doctorByFilterRequest.PageNumber - 1) * pageSize)
                    .Take(pageSize);

                return SuccessResultCreator.Create(doctors.Select(DoctorByFilterOutDto.CreateResponse));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISuccessResult<UpdateDoctorOutDto>> Update(IUpdateDoctorInDto updateDoctorRequest)
        {
            try
            {
                await _updateDoctorValidator.ValidateAndThrowAsync(updateDoctorRequest);
                                
                var doctor = await _docRepository.GetByIdAsync(updateDoctorRequest.Id);

                if (doctor == null)
                {
                    throw new NotFoundException($"Ошибка: Доктор с ID {updateDoctorRequest.Id} не найден.");
                }
                                
                var specializationTask = _specializationService.CheckSpecialization(updateDoctorRequest.Specialization);

                var officeTask = _officeService.CheckOffice(updateDoctorRequest.NumberOffice);

                var plotTask = _plotService.CheckPlot(updateDoctorRequest.NumberPlot);

                await Task.WhenAll(specializationTask, officeTask, plotTask);

                var specialization = specializationTask.Result;
                var office = officeTask.Result;
                var plot = plotTask.Result;
                
                ICreateDoctor updateDoctor = UpdaterDoctor.Create(updateDoctorRequest, specialization.Id, office.Id, plot.Id);

                doctor = UpdaterDoctorHelper.Update(doctor,updateDoctor);

                await _docRepository.UpdateAsync(doctor);

                return SuccessResultCreator.Create(true, UpdateDoctorOutDto.CreateResponse(doctor));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ISuccessResult<DeleteOutDto>> Delete(Guid doctorId)
        {
            try
            {
                _guidValidator.ValidateAndThrowAsync(doctorId);

                var doctor = await _docRepository.GetByIdAsync(doctorId);

                if (doctor == null)
                {
                    throw new NotFoundException($"Ошибка: Доктор с ID {doctorId} не найден.");
                }
                
                await _docRepository.DeleteAsync(doctor);
                
                return SuccessResultCreator.Create(true, DeleteOutDto.CreateResponse(true));
            }
            catch (Exception ex) 
            {
                throw; 
            }            
        }
    }
}