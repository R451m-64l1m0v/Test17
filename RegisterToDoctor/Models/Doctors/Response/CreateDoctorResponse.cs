using RegisterToDoctor.Domain.Core.Entities;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class CreateDoctorResponse
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id { get; private set; }

        public static CreateDoctorResponse CreateResponse(Doctor doctor) =>
            new CreateDoctorResponse { Id = doctor.Id };
    }
}
