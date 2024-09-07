using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Domen.Core.Common;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class DoctorByFilterRequest
    {
        [FromQuery]
        public string sortField { get; set; }

        [FromQuery]
        public bool ascending {  get; set; }

        [FromQuery]
        public int pageNumber { get; set; }

        [FromQuery]
        public int pageSize { get; set; }
    }
}
