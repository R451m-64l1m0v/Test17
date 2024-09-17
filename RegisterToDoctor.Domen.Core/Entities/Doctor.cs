using RegisterToDoctor.Domen.Core.RequestModels;
using RegisterToDoctor.Domen.Core.RequestModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.Entities
{
    public class Doctor : Рerson, ICreateDoctor
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
