using RegisterToDoctor.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domain.Core.Entities
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
