using RegisterToDoctor.Domain.Core.Entities;

namespace RegisterToDoctor.Domain.Core.Entities
{
    public class Doctor : РersonBase
    {
        /// <summary>
        /// Id кабинета
        /// </summary>
        public Guid OfficeId { get; set; }

        /// <summary>
        /// Id специальности
        /// </summary>
        public Guid SpecializationId { get; set; }

        /// <summary>
        /// Id участка
        /// </summary>
        public Guid PlotId { get; set; }
        
        public Office Office { get; set; }
        public Specialization Specialization { get; set; }
        public Plot Plot { get; set; }        
    }
}
