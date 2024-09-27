using RegisterToDoctor.Domain.Enums;

namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface ICreatePatient
    {
        Guid Id { get; }

        string FirstName { get;  }

        string LastName { get;  }

        string? MiddleName { get; }

        public DateTime DateOfBirth { get; }
                
        public string Address { get; }
                
        public Gender Gender { get; }
                
        public Guid PlotId { get; }
                
        public string OmsNumber { get; }
               
        public string? DmsNumber { get; }

        public DateTime? UpdatedAt { get; }
    }
}
