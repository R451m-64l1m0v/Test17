using RegisterToDoctor.Interfaces;

namespace RegisterToDoctor.Helpers.Doctor
{
    public static class СreatorDoctorHelper
    {
        public static Domain.Entities.Doctor Create(ICreateDoctor doctor)
        {
            return new Domain.Entities.Doctor
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
