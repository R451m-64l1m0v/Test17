using RegisterToDoctor.WebSell.Interfaces;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Models.Abstractions
{
    public abstract class Рerson : IPerson
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string? MiddleName { get; set; }
    }
}
