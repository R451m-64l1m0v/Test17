using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Models.Abstractions;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class DoctorByFilterResponse : РersonBase
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id { get; set; }

        /// <summary>
        /// Номер кабинета
        /// </summary>
        [JsonPropertyName("NumberOffice")]
        public int NumberOffice { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        [JsonPropertyName("SpecializationName")]
        public string SpecializationName { get; set; }

        /// <summary>
        /// Номер участка
        /// </summary>
        [JsonPropertyName("NumberPlot")]
        public int NumberPlot { get; set; }
    }
}
