using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Domen.Core.Enums;
using RegisterToDoctor.Models.Abstractions;

namespace RegisterToDoctor.Models.Patient.Request
{
    public class CreatePatientRequest : РersonBase
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
        /// Участок
        /// </summary>
        public int NumberPlot { get; set; }               
    }
}
