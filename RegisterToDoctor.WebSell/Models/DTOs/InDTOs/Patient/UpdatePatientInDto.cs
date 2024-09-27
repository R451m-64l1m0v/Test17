using System.Text.Json.Serialization;
using RegisterToDoctor.Domain.Enums;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient;

namespace RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Patient
{
    public class UpdatePatientInDto : IUpdatePatientInDto
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatientId")]
        public Guid Id { get; set; }

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
        [JsonPropertyName("DmsNumber")]
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
