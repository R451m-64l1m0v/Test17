using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.Entities
{
    public class Patient : Рerson
    {
        public string Address { get; set; }
        
        public string Gender { get; set; }

        public Plot Plot { get; set; }

        public string OmsNumder {  get; set; } 

        public string DmsNumber { get; set; }
        
        public MedicalCard MedicalCard { get; set; }
    }
}
