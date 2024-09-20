using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Domen.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.RequestModels.Interfaces
{
    public interface ICreatePatient
    {
        Guid Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string? MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }
                
        public string Address { get; set; }
                
        public Gender Gender { get; set; }
                
        public Guid PlotId { get; set; }
                
        public string OmsNumber { get; set; }
               
        public string? DmsNumber { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
