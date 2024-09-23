using RegisterToDoctor.Domain.Core.Entities;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class UpdateDoctorResponse
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id { get; private set; }

        public static UpdateDoctorResponse CreateResponse(Doctor doctor) =>
            new UpdateDoctorResponse { Id = doctor.Id };        
    }
}
