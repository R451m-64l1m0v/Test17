using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Patient.Response
{
    public class UpdatePatientResponse
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatientId")]
        public Guid Id { get; private set; }

        public static UpdatePatientResponse CreateResponse(Domain.Entities.Patient patient) =>
            new UpdatePatientResponse { Id = patient.Id };
    }
}
