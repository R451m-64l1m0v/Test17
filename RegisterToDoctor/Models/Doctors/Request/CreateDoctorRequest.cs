using Microsoft.AspNetCore.Identity;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class CreateDoctorRequest : РersonBase
    {
        /// <summary>
        /// Номер кабинета
        /// </summary>
        public int NumberOffice { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        public string Specialization { get; set; }

        /// <summary>
        /// Номер участка
        /// </summary>
        public int  NumberPlot { get; set; }
    }
}
