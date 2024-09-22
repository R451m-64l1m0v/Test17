namespace RegisterToDoctor.Models.Patient.Response
{
    public class UpdatePatientResponse
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        public Guid Id { get; private set; }

        public static UpdatePatientResponse CreateResponse(Domen.Core.Entities.Patient patient) =>
            new UpdatePatientResponse { Id = patient.Id };
    }
}
