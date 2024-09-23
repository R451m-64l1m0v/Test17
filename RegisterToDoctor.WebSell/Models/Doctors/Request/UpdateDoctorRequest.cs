using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Models.Doctors.Request
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
