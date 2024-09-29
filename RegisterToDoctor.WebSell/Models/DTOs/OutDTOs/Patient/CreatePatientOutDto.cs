using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Patient
{
    public class CreatePatientOutDto : IIdOutDto
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatientId")]
        public Guid Id { get; private set; }

        public static CreatePatientOutDto Create(Domain.Entities.Patient patient) =>
            new CreatePatientOutDto { Id = patient.Id };
    }
}
