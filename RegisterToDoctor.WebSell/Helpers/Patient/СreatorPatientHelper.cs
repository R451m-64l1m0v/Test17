using RegisterToDoctor.WebSell.Interfaces;

namespace RegisterToDoctor.WebSell.Helpers.Patient
{
    public static class СreatorPatientHelper
    {
        public static Domain.Entities.Patient Create(ICreatePatient patient)
        {
            return new Domain.Entities.Patient
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
