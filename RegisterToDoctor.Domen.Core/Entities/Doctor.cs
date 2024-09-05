using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.Entities
{
    public class Doctor : Рerson
    {
        public Office Office { get; set; }
        public Specialization Specialization { get; set; }
        public Plot Plot { get; set; }


    }
}
