using RegisterToDoctor.Infrastructure.Abstractions;
using RegisterToDoctor.WebSell.Attributes;
using RegisterToDoctor.WebSell.Interfaces.Markers;
using RegisterToDoctor.WebSell.Models.Doctors.Request;
using RegisterToDoctor.WebSell.Models.Doctors.Response;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface IDoctorService
    {
        Task<ISuccessResult<CreateDoctorResponse>> Create(ICreateDoctorRequest createDoctor);
        Task<UpdateDoctorResponse> Update(UpdateDoctorRequest updateDoctor);
        Task<DoctorByIdResponse> GetById(Guid doctorId);
        Task<IEnumerable<DoctorByFilterResponse>> GetDoctorsByFilter(DoctorByFilterRequest doctorByFilterRequest);
        Task<DeleteDoctorResponse> Delete(Guid doctorId);
    }
}
