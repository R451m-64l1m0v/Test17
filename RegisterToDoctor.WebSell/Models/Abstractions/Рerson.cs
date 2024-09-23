using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Models.Abstractions
{
    public abstract class Рerson
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
    }
}
