using Azure;
using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Domen.Core.RequestModels.Interfaces;
using RegisterToDoctor.Helpers.Doctor;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;
using RegisterToDoctor.Validators;
using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RegisterToDoctor.Services
{
    [RegisrationMarker(ServiceLifetime.Scoped)]
    public class DoctorService : IDoctorService
    {
        private readonly IDbRepository<Doctor> _docRepository;
        private readonly ISpecializationService _specializationService;
        private readonly IOfficeService _officeService;
        private readonly IPlotService _plotService;

        public DoctorService(IUnitOfWork uow,
            ISpecializationService specializationService,
            IOfficeService officeService,
            IPlotService plotService)
        {
            _docRepository = uow.DbRepository<Doctor>();
            _specializationService = specializationService;
            _officeService = officeService;
            _plotService = plotService;
        }

        public async Task<CreateDoctorResponse> Create(CreateDoctorRequest createDoctorRequest)
        {
            try
            {
                //ToDo вынести проверки
                UserEntityValidator.CheckFullNames(createDoctorRequest.FirstName, createDoctorRequest.LastName);
                
                if (string.IsNullOrWhiteSpace(createDoctorRequest.MiddleName))
                {
                    createDoctorRequest.MiddleName = null;
                }

                var specializationTask = _specializationService.CheckSpecialization(createDoctorRequest.Specialization);

                var officeTask = _officeService.CheckOffice(createDoctorRequest.NumberOffice);

                var plotTask = _plotService.CheckPlot(createDoctorRequest.NumberPlot);

                await Task.WhenAll(specializationTask, officeTask, plotTask);

                var specialization = specializationTask.Result;
                var office = officeTask.Result;
                var plot = plotTask.Result;

                ICreateDoctor createDoctor = CreatorDoctor.Create(createDoctorRequest, specialization.Id, office.Id, plot.Id);

                var doctor = СreatorDoctorHelper.Create(createDoctor);
                
                _docRepository.Create(doctor);

                return CreateDoctorResponse.CreateResponse(doctor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DoctorByIdResponse> GetById(Guid doctorId)
        {
            try
            {
                if (doctorId == Guid.Empty)
                {
                    throw new ArgumentException($"Ошибка id доктора не может быть {doctorId}");
                }

                var doctor = _docRepository.GetById(doctorId);

                if (doctor == null)
                {
                    return null;
                }

                return DoctorByIdResponse.CreateResponse(doctor);                  
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<DoctorByFilterResponse>> GetDoctorsByFilter(DoctorByFilterRequest doctorByFilterRequest)
        {
            try
            {
                //ToDo вынести проверки
                if (doctorByFilterRequest.PageNumber == 0)
                    throw new ArgumentException($"Ошибка не указан {nameof(doctorByFilterRequest.PageNumber)}");

                if (doctorByFilterRequest.PageSize == 0)
                    throw new ArgumentException($"Ошибка не указан {nameof(doctorByFilterRequest.PageSize)}");                

                var doctors = _docRepository.Entity
                    .Include(x => x.Office)
                    .Include(x => x.Specialization)
                    .Include(x => x.Plot)
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
                    .Skip((doctorByFilterRequest.PageNumber - 1) * doctorByFilterRequest.PageSize)
                    .Take(doctorByFilterRequest.PageSize);
                                
                return doctors.Select(doctor => DoctorByFilterResponse.CreateResponse(doctor));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UpdateDoctorResponse> Update(UpdateDoctorRequest updateDoctorRequest)
        {
            try
            {
                //ToDo вынести проверки
                if (updateDoctorRequest.Id == Guid.Empty)
                {
                    throw new ArgumentException($"Ошибка id доктора не может быть {updateDoctorRequest.Id}");
                }

                UserEntityValidator.CheckFullNames(updateDoctorRequest.FirstName, updateDoctorRequest.LastName);

                if (string.IsNullOrWhiteSpace(updateDoctorRequest.MiddleName))
                {
                    updateDoctorRequest.MiddleName = null;
                }

                var doctor = _docRepository.GetById(updateDoctorRequest.Id);

                if (doctor == null)
                {
                    return null;
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

                _docRepository.Update(doctor);

                return UpdateDoctorResponse.CreateResponse(doctor);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
