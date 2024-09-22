using RegisterToDoctor.Domen.Core.Entities;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class UpdateDoctorResponse
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        public Guid Id { get; private set; }

        public static UpdateDoctorResponse CreateResponse(Doctor doctor) =>
            new UpdateDoctorResponse { Id = doctor.Id };        
    }
}
