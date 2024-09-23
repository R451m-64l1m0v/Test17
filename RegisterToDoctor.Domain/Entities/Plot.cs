using RegisterToDoctor.Domain.Common;

namespace RegisterToDoctor.Domain.Entities
{
    public class Plot : BaseEntity
    {
        /// <summary>
        /// Номер участка
        /// </summary>
        public int Number {  get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
