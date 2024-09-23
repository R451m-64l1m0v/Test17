using RegisterToDoctor.Domain.Common;

namespace RegisterToDoctor.Domain.Entities
{
    public class Specialization : BaseEntity
    {
        /// <summary>
        /// Название специальности
        /// </summary>
        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
