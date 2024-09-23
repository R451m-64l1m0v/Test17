using RegisterToDoctor.Interfaces;

namespace RegisterToDoctor.Helpers.Patient
{
    public static class СreatorPatientHelper
    {
        public static Domain.Core.Entities.Patient Create(ICreatePatient patient)
        {
            return new Domain.Core.Entities.Patient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                MiddleName = patient.MiddleName,
                DateOfBirth = patient.DateOfBirth,
                Address = patient.Address,
                Gender = patient.Gender,
                OmsNumber = patient.OmsNumber,
                DmsNumber = patient.DmsNumber,
                PlotId = patient.PlotId,
                UpdatedAt = patient.UpdatedAt,
            };
        }
    }
}
