using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class UpdateDoctorRequest : CreateDoctorRequest
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        public Guid Id { get; set; }
    }
}
