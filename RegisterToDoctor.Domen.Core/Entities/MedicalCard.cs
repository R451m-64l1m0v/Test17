using RegisterToDoctor.Domen.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.Entities
{
    public class MedicalCard : BaseEntity
    {
        /// <summary>
        /// Номер мед. карты
        /// </summary>
        public int Number { get; set; }

        public Guid PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
