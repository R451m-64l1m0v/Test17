using RegisterToDoctor.Interfaces;

namespace RegisterToDoctor.Helpers.Patient
{
    public static class UpdaterPatientHelper
    {
        public static Domain.Core.Entities.Patient Update(Domain.Core.Entities.Patient patient, ICreatePatient updatePatient)
        {
            patient.FirstName = updatePatient.FirstName;
            patient.LastName = updatePatient.LastName;
            patient.MiddleName = updatePatient.MiddleName;
            patient.DateOfBirth = updatePatient.DateOfBirth;
            patient.Address = updatePatient.Address;
            patient.Gender = updatePatient.Gender;
            patient.OmsNumber = updatePatient.OmsNumber;
            patient.PlotId = updatePatient.PlotId;
            patient.UpdatedAt = updatePatient.UpdatedAt;
            return patient;
        }
    }
}
