using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Domen.Core.Common;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class DoctorByFilterRequest
    {
        [FromQuery]
        public string SortField { get; set; }

        [FromQuery]
        public bool Ascending {  get; set; }

        [FromQuery]
        public int PageNumber { get; set; }

        [FromQuery]
        public int PageSize { get; set; }
    }
}
