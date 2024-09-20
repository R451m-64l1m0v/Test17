using RegisterToDoctor.Domen.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.Entities
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
