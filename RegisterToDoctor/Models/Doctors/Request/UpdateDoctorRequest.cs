using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class UpdateDoctorRequest : CreateDoctorRequest
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id { get; set; }
    }
}
