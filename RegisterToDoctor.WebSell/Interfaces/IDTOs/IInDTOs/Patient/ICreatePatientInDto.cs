using RegisterToDoctor.Domain.Enums;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient
{
    public interface ICreatePatientInDto : IPerson
    {
        public DateTime DateOfBirth { get;}
        public string OmsNumber { get;}
        public string? DmsNumber { get;  }
        public string Address { get; }
        public Gender Gender { get;  }
        public int NumberPlot { get; }
    }
}
