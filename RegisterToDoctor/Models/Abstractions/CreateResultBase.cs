using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Abstractions
{
    public class CreateResultBase
    {
        /// <summary>
        /// Результат создания
        /// </summary>
        [JsonPropertyName("IsSecceed")]
        public bool IsSecceed { get; set; }
    }
}
