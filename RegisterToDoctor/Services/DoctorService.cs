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
                var specializationTask = _specializationService.CheckSpecialization(createDoctor.Specialization);

                var officeTask = _officeService.CheckOffice(createDoctor.NumberOffice);

                var plotTask = _plotService.CheckPlot(createDoctor.NumberPlot);

                await Task.WhenAll(specializationTask, officeTask, plotTask);

                var specialization = specializationTask.Result;
                var office = officeTask.Result;
                var plot = plotTask.Result;

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

                var doctorResponse = new DoctorByIdResponse
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
            catch (Exception)
            {
                throw;
            }
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
                        SpecializationName = doctor.Specialization.Name,
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
                if (updateDoctor.Id == Guid.Empty)
                {
                    throw new ArgumentException($"Ошибка id доктора не может быть {updateDoctor.Id}");
                }

                var specializationTask = _specializationService.CheckSpecialization(updateDoctor.Specialization);

                var officeTask = _officeService.CheckOffice(updateDoctor.NumberOffice);

                var plotTask = _plotService.CheckPlot(updateDoctor.NumberPlot);

                await Task.WhenAll(specializationTask, officeTask, plotTask);

                var specialization = specializationTask.Result;
                var office = officeTask.Result;
                var plot = plotTask.Result;

                if (string.IsNullOrWhiteSpace(updateDoctor.FirstName) ||
                    string.IsNullOrWhiteSpace(updateDoctor.LastName))
                    throw new ArgumentException($"Ошибка не заполнены поля ФИО");

                if (string.IsNullOrWhiteSpace(updateDoctor.MiddleName))
                {
                    updateDoctor.MiddleName = null;
                }

                var doctor = _docRepository.GetById(updateDoctor.Id);

                if (doctor != null)
                {
                    doctor.FirstName = updateDoctor.FirstName;
                    doctor.LastName = updateDoctor.LastName;
                    doctor.MiddleName = updateDoctor.MiddleName;
                    doctor.OfficeId = office.Id;
                    doctor.SpecializationId = specialization.Id;
                    doctor.PlotId = plot.Id;
                }
                else
                    return null;

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
