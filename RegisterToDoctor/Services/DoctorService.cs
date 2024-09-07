using Azure;
using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Attributes;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Infrastructure.Data.Interfaces;
using RegisterToDoctor.Interfaces;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;
using System.Threading.Tasks;

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
                    string.IsNullOrWhiteSpace(createDoctor.LastName) ||
                    string.IsNullOrWhiteSpace(createDoctor.MiddleName))
                    throw new ArgumentException($"Ошибка не заполнены поля ФИО");

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
            var doctors = await _docRepository.Entity
                .Where(x => x.Id == doctorId)
                .Include(x => x.Office)
                .Include(x => x.Plot)
                .Include(x => x.Specialization)
                .ToListAsync();

            if (!doctors.Any())
            {
                return null;
            }

            var doctor = doctors.FirstOrDefault();

            var doctorResponse = new DoctorResponse
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                MiddleName = doctor.MiddleName,
                NumberOffice = doctor.Office.Number,
                NumberPlot = doctor.Plot.Number,
                Specialization = doctor.Specialization.Name,
            };

            return doctorResponse;
        }

        public Task<DoctorByFilterResponse> GetDoctorsByFilter(DoctorByFilterRequest doctorByFilterRequest)
        {

            throw new NotImplementedException();
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
