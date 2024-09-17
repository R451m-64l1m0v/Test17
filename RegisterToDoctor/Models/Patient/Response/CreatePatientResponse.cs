using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;
using RegisterToDoctor.Models.Doctors.Response;

namespace RegisterToDoctor.Models.Patient.Response
{
    public class CreatePatientResponse
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        public Guid Id { get; private set; }

        public static CreatePatientResponse CreateResponse(Domen.Core.Entities.Patient patient) => 
            new CreatePatientResponse { Id = patient.Id };
    }
            
        
    
}
