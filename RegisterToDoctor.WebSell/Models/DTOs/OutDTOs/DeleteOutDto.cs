using RegisterToDoctor.Domain.Entities;
using RegisterToDoctor.WebSell.Models.Abstractions;
using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs
{
    public class DeleteOutDto : IDeleteResponseOutDto
    {
        /// <summary>
        /// Результат удаления
        /// </summary>
        [JsonPropertyName("IsSecceed")]
        public bool IsSecceed { get; set; }

        public static DeleteOutDto CreateResponse(bool isSecceed) =>
            new DeleteOutDto { IsSecceed = isSecceed };
    }
}