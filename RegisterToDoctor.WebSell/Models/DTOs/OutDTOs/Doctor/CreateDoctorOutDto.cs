using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Doctor
{
    public class CreateDoctorOutDto : IIdOutDto
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("Id")]
        public Guid Id { get; private set; }

        public static CreateDoctorOutDto Create(Domain.Entities.Doctor doctor) =>
            new CreateDoctorOutDto { Id = doctor.Id };
    }
}
