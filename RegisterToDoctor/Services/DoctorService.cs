using Azure;
using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Helpers;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;
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

        public async Task<CreateDoctorResponse> Create(CreateDoctorRequest createDoctor)
        {
            try
            {
                var specialization = await _specializationService.CheckSpecialization(createDoctor.Specialization);

                var office = await _officeService.CheckOffice(createDoctor.NumberOffice);

                var plot = await _plotService.CheckPlot(createDoctor.NumberPlot);

                if (string.IsNullOrWhiteSpace(createDoctor.FirstName) ||
                    string.IsNullOrWhiteSpace(createDoctor.LastName))
                    throw new ArgumentException($"Ошибка не заполнены поля Фамилии или Имени");

                if (string.IsNullOrWhiteSpace(createDoctor.MiddleName))
                {
                    createDoctor.MiddleName = null;
                }

                var doctor = new Doctor
                {
                    Id = Guid.NewGuid(),
                    FirstName = createDoctor.FirstName,
                    LastName = createDoctor.LastName,
                    MiddleName = createDoctor.MiddleName,
                    DateOfBirth = null,
                    OfficeId = office.Id,
                    PlotId = plot.Id,
                    SpecializationId = specialization.Id,
                };

                _docRepository.Create(doctor);

                return new CreateDoctorResponse { IsSecceed = true };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DoctorResponse> GetById(Guid doctorId)
        {
            var doctor = await _docRepository.Entity
                .FirstOrDefaultAsync(x => x.Id == doctorId);

            if (doctor == null)
            {
                return null;
            }

            var doctorResponse = new DoctorResponse
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                MiddleName = doctor.MiddleName,
                OfficeId = doctor.OfficeId,
                PlotId = doctor.PlotId,
                SpecializationId = doctor.SpecializationId,
            };

            return doctorResponse;
        }

        public async Task<List<DoctorByFilterResponse>> GetDoctorsByFilter(DoctorByFilterRequest doctorByFilterRequest)
        {
            try
            {
                if (doctorByFilterRequest.PageNumber == 0)
                    throw new ArgumentException($"Ошибка не указан {nameof(doctorByFilterRequest.PageNumber)}");

                if (doctorByFilterRequest.PageSize == 0)
                    throw new ArgumentException($"Ошибка не указан {nameof(doctorByFilterRequest.PageSize)}");

                var isSortField = DoctorHelper.CheckingSortingField(doctorByFilterRequest.SortField);

                if (!isSortField)
                {
                    throw new ArgumentException($"Ошибка поля {doctorByFilterRequest.SortField} не найдено");
                }

                var doctors = _docRepository.Entity
                    .Include(v => v.Office)
                    .Include(v => v.Specialization)
                    .Include(v => v.Plot)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(doctorByFilterRequest.SortField))
                {
                    var parameter = Expression.Parameter(typeof(Doctor), "e");
                    var property = Expression.Property(parameter, doctorByFilterRequest.SortField);
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
                }

                doctors = doctors
                    .Skip((doctorByFilterRequest.PageNumber - 1) * doctorByFilterRequest.PageSize)
                    .Take(doctorByFilterRequest.PageSize);

                var doctorsByFilter = new List<DoctorByFilterResponse>();

                foreach (var doctor in doctors)
                {
                    var doctorByFilter = new DoctorByFilterResponse
                    {
                        Id = doctor.Id,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        MiddleName = doctor.MiddleName,
                        NumberOffice = doctor.Office.Number,
                        Specialization = doctor.Specialization.Name,
                        NumberPlot = doctor.Plot.Number,
                    };

                    doctorsByFilter.Add(doctorByFilter);
                }

                return doctorsByFilter;
            }
            catch (Exception)
            {

                throw;
            }                      
        }

        public async Task<UpdateDoctorResponse> Update(UpdateDoctorRequest updateDoctor)
        {
            try
            {
                var specialization = await _specializationService.CheckSpecialization(updateDoctor.Specialization);

                var office = await _officeService.CheckOffice(updateDoctor.NumberOffice);

                var plot = await _plotService.CheckPlot(updateDoctor.NumberPlot);

                if (string.IsNullOrWhiteSpace(updateDoctor.FirstName) ||
                    string.IsNullOrWhiteSpace(updateDoctor.LastName) ||
                    string.IsNullOrWhiteSpace(updateDoctor.MiddleName))
                    throw new ArgumentException($"Ошибка не заполнены поля ФИО");

                var doctor = new Doctor
                {
                    Id = Guid.NewGuid(),
                    FirstName = updateDoctor.FirstName,
                    LastName = updateDoctor.LastName,
                    MiddleName = updateDoctor.MiddleName,
                    DateOfBirth = null,
                    OfficeId = office.Id,
                    PlotId = plot.Id,
                    SpecializationId = specialization.Id,
                };

                _docRepository.Update(doctor);

                return new UpdateDoctorResponse { IsSecceed = true };
            }
            catch (Exception)
            {
                throw;
            }




        }


    }
}
