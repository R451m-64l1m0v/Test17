using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;


namespace RegisterToDoctor.Models.Doctors.Response
{
    public class CreateDoctorResponse
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        public Guid Id { get; private set; }

        public static CreateDoctorResponse CreateResponse(Doctor doctor) =>
            new CreateDoctorResponse { Id = doctor.Id };
    }
}
