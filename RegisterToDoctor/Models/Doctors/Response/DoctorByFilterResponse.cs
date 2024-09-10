using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class DoctorByFilterResponse
    {
        private readonly Doctor _doctor;

        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id => _doctor.Id;

        /// <summary>
        /// Имя
        /// </summary>
        [JsonPropertyName("FirstName")]
        public string FirstName => _doctor.FirstName;

        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonPropertyName("LastName")]
        public string LastName => _doctor.LastName;

        /// <summary>
        /// Отчество
        /// </summary>
        [JsonPropertyName("MiddleName")]
        public string MiddleName => _doctor.MiddleName;

        /// <summary>
        /// Номер кабинета
        /// </summary>
        [JsonPropertyName("NumberOffice")]
        public int NumberOffice => _doctor.Office.Number;

        /// <summary>
        /// Название специальности
        /// </summary>
        [JsonPropertyName("SpecializationName")]
        public string SpecializationName => _doctor.Specialization.Name;

        /// <summary>
        /// Номер участка
        /// </summary>
        [JsonPropertyName("NumberPlot")]
        public int NumberPlot => _doctor.Plot.Number;

        public DoctorByFilterResponse(Doctor doctor)
        {
            _doctor = doctor;                       
        }

        public static DoctorByFilterResponse Create(Doctor doctor) => new DoctorByFilterResponse(doctor);
    }
}
