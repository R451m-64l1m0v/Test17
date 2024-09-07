using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.Entities
{
    public class Doctor : Рerson
    {
        public Guid OfficeId { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid PlotId { get; set; }

        public Office Office { get; set; }
        public Specialization Specialization { get; set; }
        public Plot Plot { get; set; }
    }
}
