using System.Text.Json.Serialization;
using RegisterToDoctor.Domain.Entities;

namespace RegisterToDoctor.WebSell.Models.Doctors.Response
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
