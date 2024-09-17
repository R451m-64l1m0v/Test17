﻿using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Domen.Core.RequestModels.Interfaces;

namespace RegisterToDoctor.Helpers.Patient
{
    public static class UpdaterPatientHelper
    {
        public static Domen.Core.Entities.Patient Update(Domen.Core.Entities.Patient patient, ICreatePatient updatePatient)
        {
            patient.FirstName = updatePatient.FirstName;
            patient.LastName = updatePatient.LastName;
            patient.MiddleName = updatePatient.MiddleName;
            patient.DateOfBirth = updatePatient.DateOfBirth;
            patient.Address = updatePatient.Address;
            patient.Gender = updatePatient.Gender;
            patient.OmsNumber = updatePatient.OmsNumber;
            patient.PlotId = updatePatient.PlotId;
            return patient;
        }
    }
}
