using RegisterToDoctor.Domen.Core.RequestModels.Interfaces;
using System.Numerics;

namespace RegisterToDoctor.Helpers.Doctor
{
    public static class СreatorDoctorHelper
    {
        public static Domen.Core.Entities.Doctor Create(ICreateDoctor doctor)
        {
            return new Domen.Core.Entities.Doctor
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                MiddleName = doctor.MiddleName,
                OfficeId = doctor.OfficeId,
                PlotId = doctor.PlotId,
                SpecializationId = doctor.SpecializationId,
                UpdatedAt = doctor.UpdatedAt,
            };
        }
    }
}
