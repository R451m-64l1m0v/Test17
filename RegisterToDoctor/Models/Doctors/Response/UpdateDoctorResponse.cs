using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;

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
