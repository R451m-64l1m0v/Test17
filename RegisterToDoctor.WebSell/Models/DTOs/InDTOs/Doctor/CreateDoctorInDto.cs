using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;

namespace RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor
{
    public class CreateDoctorInDto : ICreateDoctorInDto
    {
        /// <summary>
        /// Имя
        /// </summary>
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [JsonPropertyName("MiddleName")]
        public string? MiddleName { get; set; }

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
        public int NumberPlot { get; set; }
    }
}
