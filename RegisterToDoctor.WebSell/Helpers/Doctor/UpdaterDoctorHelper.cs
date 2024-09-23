using RegisterToDoctor.WebSell.Interfaces;

namespace RegisterToDoctor.WebSell.Helpers.Doctor
{
    public static class UpdaterDoctorHelper
    {
        public static Domain.Entities.Doctor Update(Domain.Entities.Doctor doctor, ICreateDoctor updateDoctor)
        {
            doctor.FirstName = updateDoctor.FirstName;
            doctor.LastName = updateDoctor.LastName;
            doctor.MiddleName = updateDoctor.MiddleName;
            doctor.OfficeId = updateDoctor.OfficeId;
            doctor.SpecializationId = updateDoctor.SpecializationId;
            doctor.PlotId = updateDoctor.PlotId;
            doctor.UpdatedAt = updateDoctor.UpdatedAt;
            return doctor;
        }
    }
}
