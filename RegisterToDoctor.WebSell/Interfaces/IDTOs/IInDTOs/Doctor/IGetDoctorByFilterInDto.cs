using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.WebSell.Models.Enum;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor
{
    public interface IGetDoctorByFilterInDto : IGetByFilterInDto
    {
        public DoctorSortField SortField { get; }
    }
}
