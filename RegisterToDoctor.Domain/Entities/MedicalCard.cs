using RegisterToDoctor.Domain.Common;

namespace RegisterToDoctor.Domain.Entities
{
    public class MedicalCard : BaseEntity
    {
        /// <summary>
        /// Номер мед. карты
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Id пациента
        /// </summary>
        public Guid PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
