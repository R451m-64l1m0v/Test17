using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Domen.Core.Enums;
using RegisterToDoctor.Models.Abstractions;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Patient.Request
{
    public class CreatePatientRequest : РersonBase
    {
        /// <summary>
        /// Дата рождения
        /// </summary>
        [JsonPropertyName("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Номер омс
        /// </summary>
        [JsonPropertyName("OmsNumber")]
        public string OmsNumber { get; set; }

        /// <summary>
        /// Номер дмс
        /// </summary>
        [JsonPropertyName("OmsNumder")]
        public string? DmsNumber { get; set; }

        /// <summary>
        /// Адресс
        /// </summary>
        [JsonPropertyName("Address")]
        public string Address { get; set; }

        /// <summary>
        /// Пол
        /// </summary> 
        [JsonPropertyName("Gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Участок
        /// </summary>
        [JsonPropertyName("NumberPlot")]
        public int NumberPlot { get; set; }               
    }
}
