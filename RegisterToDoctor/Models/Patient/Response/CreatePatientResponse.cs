using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Patient.Response
{
    public class CreatePatientResponse
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatientId")]
        public Guid Id { get; private set; }

        public static CreatePatientResponse CreateResponse(Domain.Core.Entities.Patient patient) => 
            new CreatePatientResponse { Id = patient.Id };
    }          
}
