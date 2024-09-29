using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs
{
    public class DeleteOutDto : IDeleteOutDto
    {
        /// <summary>
        /// Результат удаления
        /// </summary>
        [JsonPropertyName("IsSecceed")]
        public bool IsSecceed { get; set; }

        public static DeleteOutDto Create(bool isSecceed) =>
            new DeleteOutDto { IsSecceed = isSecceed };
    }
}