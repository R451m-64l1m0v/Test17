using RegisterToDoctor.Infrastructure.Abstractions;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient;
using RegisterToDoctor.WebSell.Interfaces.Markers;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Patient;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Patient;

namespace RegisterToDoctor.WebSell.Interfaces.IServices
{
    public interface IPatientService
    {
        Task<ISuccessResult<CreatePatientOutDto>> Create(ICreatePatientInDto createDoctorInDto);
        Task<ISuccessResult<UpdatePatientOutDto>> Update(IUpdatePatientInDto updateDoctorInDto);
        Task<ISuccessResult<PatientByIdOutDto>> GetById(Guid doctorId);
        Task<ISuccessResult<IEnumerable<GetPatienFindByFilterOutDto>>> GetPatientByFilter(IGetPatientFindByFilterInDto getPatientFindByFilterInDto);
        Task<ISuccessResult<DeleteOutDto>> Delete(Guid doctorId);
    }
}
