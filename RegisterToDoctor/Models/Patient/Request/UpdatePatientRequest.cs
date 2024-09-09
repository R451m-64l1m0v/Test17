namespace RegisterToDoctor.Models.Patient.Request
{
    public class UpdatePatientRequest : CreatePatientRequest
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        public Guid Id { get; set; }
    }
}
