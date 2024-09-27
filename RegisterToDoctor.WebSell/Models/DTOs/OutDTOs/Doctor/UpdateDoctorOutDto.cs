using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Doctor
{
    public class UpdateDoctorOutDto : IResponseIdOutDto
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id { get; private set; }

        public static UpdateDoctorOutDto CreateResponse(Domain.Entities.Doctor doctor) =>
            new UpdateDoctorOutDto { Id = doctor.Id };
    }
}
