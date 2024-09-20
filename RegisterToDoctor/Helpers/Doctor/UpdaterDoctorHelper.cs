using RegisterToDoctor.Domen.Core.RequestModels.Interfaces;

namespace RegisterToDoctor.Helpers.Doctor
{
    public static class UpdaterDoctorHelper
    {
        public static Domen.Core.Entities.Doctor Update(Domen.Core.Entities.Doctor doctor, ICreateDoctor updateDoctor)
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
