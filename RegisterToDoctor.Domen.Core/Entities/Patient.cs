using RegisterToDoctor.Domen.Core.Enums;
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
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Адресс
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Id участока 
        /// </summary>
        public Guid PlotId { get; set; }

        /// <summary>
        /// Номер OMC
        /// </summary>
        public string OmsNumber {  get; set; } 

        /// <summary>
        /// Номер ДМС
        /// </summary>
        public string? DmsNumber { get; set; }

        /// <summary>
        /// Участок
        /// </summary>
        public Plot Plot { get; set; }

        /// <summary>
        /// Медицинская карта
        /// </summary>
        public MedicalCard MedicalCard { get; set; }
    }
}
