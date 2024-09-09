using RegisterToDoctor.Domen.Core.Enums;
using RegisterToDoctor.Models.Abstractions;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Patient.Response
{
    public class PatienByFilterResponse : РersonBase
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatienId")]
        public Guid Id { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [JsonPropertyName("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

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
