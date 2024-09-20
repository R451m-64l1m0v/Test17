using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domen.Core.RequestModels.Interfaces
{
    public interface ICreateDoctor
    {
        Guid Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string? MiddleName { get; set; }

        Guid OfficeId { get; set; }

        Guid SpecializationId { get; set; }

        Guid PlotId { get; set; }

        DateTime? UpdatedAt { get; set; }
    }
}
