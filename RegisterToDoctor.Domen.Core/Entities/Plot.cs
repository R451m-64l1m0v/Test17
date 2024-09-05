using RegisterToDoctor.Domen.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.Entities
{
    public class Plot : BaseEntity
    {
        public int Number {  get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
