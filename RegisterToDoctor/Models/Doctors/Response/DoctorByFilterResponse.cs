using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class DoctorByFilterResponse
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id { get; private set; }

        /// <summary>
        /// Имя
        /// </summary>
        [JsonPropertyName("FirstName")]
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonPropertyName("LastName")]
        public string LastName { get; private set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [JsonPropertyName("MiddleName")]
        public string? MiddleName { get; private set; }

        /// <summary>
        /// Номер кабинета
        /// </summary>
        [JsonPropertyName("NumberOffice")]
        public int NumberOffice { get; private set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        [JsonPropertyName("SpecializationName")]
        public string SpecializationName { get; private set; }

        /// <summary>
        /// Номер участка
        /// </summary>
        [JsonPropertyName("NumberPlot")]
        public int NumberPlot { get; private set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        [JsonPropertyName("UpdatedAt")]
        public DateTime? UpdatedAt { get; private set; }

        public static DoctorByFilterResponse CreateResponse(Doctor doctor) => new DoctorByFilterResponse
        {
            Id = doctor.Id,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            MiddleName = doctor.MiddleName,
            NumberOffice = doctor.Office.Number,
            SpecializationName = doctor.Specialization.Name,
            NumberPlot = doctor.Plot.Number,
            UpdatedAt = doctor.UpdatedAt,
        };
    }
}
