using RegisterToDoctor.Models.Abstractions;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class CreateDoctorRequest : Рerson
    {
        /// <summary>
        /// Номер кабинета
        /// </summary>
        [JsonPropertyName("NumberOffice")]
        public int NumberOffice { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        [JsonPropertyName("Specialization")]
        public string Specialization { get; set; }

        /// <summary>
        /// Номер участка
        /// </summary>
        [JsonPropertyName("NumberPlot")]
        public int  NumberPlot { get; set; }
    }
}
