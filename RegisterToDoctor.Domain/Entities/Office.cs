using RegisterToDoctor.Domain.Common;

namespace RegisterToDoctor.Domain.Entities
{
    public class Office : BaseEntity
    {
        /// <summary>
        /// Номер кабинета
        /// </summary>
        public int Number {  get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
