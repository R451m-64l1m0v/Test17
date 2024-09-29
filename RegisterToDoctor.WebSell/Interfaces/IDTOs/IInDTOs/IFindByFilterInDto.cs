using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs
{
    public interface IFindByFilterInDto
    {
        public bool Ascending { get; }
        public int PageNumber { get; }
        public int PageSizeMin { get; }
        public int PageSizeMax { get; }
    }
}
