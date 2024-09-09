using RegisterToDoctor.Models.Enum;

namespace RegisterToDoctor.Helpers
{
    public static class PatientHelper
    {
        public static bool CheckingSortingField(PatientSortField sortField)
        {
            try
            {
                return Enum.IsDefined(typeof(PatientSortField), sortField);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
