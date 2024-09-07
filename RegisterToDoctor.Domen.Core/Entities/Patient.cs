using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.Entities
{
    public class Patient : Рerson
    {
        /// <summary>
        /// Адресс
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Пол
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Участок
        /// </summary>
        public Plot Plot { get; set; }

        /// <summary>
        /// Номер OMC
        /// </summary>
        public string OmsNumder {  get; set; } 

        /// <summary>
        /// Номер ДМС
        /// </summary>
        public string DmsNumber { get; set; }
        

        public MedicalCard MedicalCard { get; set; }
    }
}
