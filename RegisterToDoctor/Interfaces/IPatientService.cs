using RegisterToDoctor.Models.Doctors.Request;
using RegisterToDoctor.Models.Doctors.Response;
using RegisterToDoctor.Models.Patient.Request;
using RegisterToDoctor.Models.Patient.Response;

namespace RegisterToDoctor.Interfaces
{
    public interface IPatientService
    {
        Task<CreatePatientResponse> Create(CreatePatientRequest createDoctor);
        Task<UpdatePatientResponse> Update(UpdatePatientRequest updateDoctor);
        Task<PatientByIdResponse> GetById(Guid doctorId);
        Task<List<PatienByFilterResponse>> GetPatientByFilter(PatientByFilterRequest doctorByFilterRequest);
    }
}
