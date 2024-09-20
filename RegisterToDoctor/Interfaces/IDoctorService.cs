using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;

namespace RegisterToDoctor.Interfaces
{
    public interface IDoctorService
    {
        Task<CreateDoctorResponse> Create(CreateDoctorRequest createDoctor);
        Task<UpdateDoctorResponse> Update(UpdateDoctorRequest updateDoctor);
        Task<DoctorByIdResponse> GetById(Guid doctorId);
        Task<IEnumerable<DoctorByFilterResponse>> GetDoctorsByFilter(DoctorByFilterRequest doctorByFilterRequest);
        Task<DeleteDoctorResponse> Delete(Guid doctorId);
    }
}
