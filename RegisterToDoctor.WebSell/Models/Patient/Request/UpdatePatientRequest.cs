using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Models.Patient.Request
{
    public class UpdatePatientRequest : CreatePatientRequest
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatientId")]
        public Guid Id { get; set; }
    }
}
