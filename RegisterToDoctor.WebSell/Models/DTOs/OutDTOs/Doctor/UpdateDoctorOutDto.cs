using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Doctor
{
    public class UpdateDoctorOutDto : IIdOutDto
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("Id")]
        public Guid Id { get; private set; }

        public static UpdateDoctorOutDto Create(Domain.Entities.Doctor doctor) =>
            new UpdateDoctorOutDto { Id = doctor.Id };
    }
}
