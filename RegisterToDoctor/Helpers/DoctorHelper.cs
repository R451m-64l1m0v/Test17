using RegisterToDoctor.Models.Doctors.Response;

namespace RegisterToDoctor.Helpers
{
    public static class DoctorHelper
    {
        public static bool CheckingSortingField(string sortField)
        {
            try
            {
                var a = nameof(DoctorByFilterResponse.Id).ToLower();

                if (sortField.ToLower() == nameof(DoctorByFilterResponse.FirstName).ToLower() 
                   || sortField.ToLower() == nameof(DoctorByFilterResponse.LastName).ToLower()
                   || sortField.ToLower() == nameof(DoctorByFilterResponse.MiddleName).ToLower()
                   || sortField.ToLower() == nameof(DoctorByFilterResponse.NumberPlot).ToLower()
                   || sortField.ToLower() == nameof(DoctorByFilterResponse.NumberOffice).ToLower()
                   || sortField.ToLower() == nameof(DoctorByFilterResponse.Specialization).ToLower()
                   || sortField.ToLower() == nameof(DoctorByFilterResponse.Id).ToLower())
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
