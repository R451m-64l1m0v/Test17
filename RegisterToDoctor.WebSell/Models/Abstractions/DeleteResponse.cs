using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Models.Abstractions
{
    public abstract class DeleteResponse
    {
        /// <summary>
        /// Результат удаления
        /// </summary>
        [JsonPropertyName("IsSecceed")]
        public bool IsSecceed { get; set; }
    }
}
