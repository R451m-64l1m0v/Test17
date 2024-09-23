using RegisterToDoctor.WebSell.Models.Patient.Request;
using RegisterToDoctor.WebSell.Models.Patient.Response;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface IPatientService
    {
        Task<CreatePatientResponse> Create(CreatePatientRequest createDoctor);
        Task<UpdatePatientResponse> Update(UpdatePatientRequest updateDoctor);
        Task<PatientByIdResponse> GetById(Guid doctorId);
        Task<IEnumerable<PatienByFilterResponse>> GetPatientByFilter(PatientByFilterRequest doctorByFilterRequest);
        Task<DeletePatientResponse> Delete(Guid doctorId);
    }
}
