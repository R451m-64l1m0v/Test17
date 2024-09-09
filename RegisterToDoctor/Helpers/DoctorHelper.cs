using RegisterToDoctor.Models.Doctors.Response;
using RegisterToDoctor.Models.Enum;

namespace RegisterToDoctor.Helpers
{
    public static class DoctorHelper
    {
        public static bool CheckingSortingField(DoctorSortField sortField)
        {
            try
            {
                return Enum.IsDefined(typeof(DoctorSortField), sortField);               
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
