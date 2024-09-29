using RegisterToDoctor.Infrastructure.Abstractions;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs;
using RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Doctor;

namespace RegisterToDoctor.WebSell.Interfaces.IServices
{
    public interface IDoctorService
    {
        Task<ISuccessResult<CreateDoctorOutDto>> Create(ICreateDoctorInDto createDoctorInDto);
        Task<ISuccessResult<DoctorByIdOutDto>> GetById(Guid doctorId);
        Task<ISuccessResult<UpdateDoctorOutDto>> Update(IUpdateDoctorInDto updateDoctorInDto);
        Task<ISuccessResult<IEnumerable<DoctorByFilterOutDto>>> GetDoctorsByFilter(IDoctorByFilterInDto doctorByFilterInDto);
        Task<ISuccessResult<DeleteOutDto>> Delete(Guid doctorId);
    }
}
