using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Models.Enum;

namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs
{
    public interface IFindByFilterInDto
    {
        public SortOrder SortOrder { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
