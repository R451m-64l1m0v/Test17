using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Doctor;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IInDTOs.Patient;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Doctor;
using RegisterToDoctor.WebSell.Models.DTOs.InDTOs.Patient;
using RegisterToDoctor.WebSell.Models.Enum;

namespace RegisterToDoctor.WebSell.Helpers.Doctor
{
    public static class SorterUtility
    {
        public static IQueryable<Domain.Entities.Doctor> DoctorSorting(IQueryable<Domain.Entities.Doctor> doctors,
            IGetDoctorFindByFilterInDto filterInDto)
        {
            if (filterInDto.SortField == DoctorSortField.SpecializationName)
            {
                return ApplySorting(doctors, filterInDto.SortField, filterInDto.SortOrder, d => d.Specialization.Name);
            }

            if (filterInDto.SortField == DoctorSortField.PlotNumber)
            {
                return ApplySorting(doctors, filterInDto.SortField, filterInDto.SortOrder, d => d.Plot.Number);
            }

            if (filterInDto.SortField == DoctorSortField.OfficeNumber)
            {
                return ApplySorting(doctors, filterInDto.SortField, filterInDto.SortOrder, d => d.Office.Number);
            }

            if (filterInDto.SortField == DoctorSortField.None)
            {
                return ApplySorting(doctors, filterInDto.SortField, filterInDto.SortOrder, d => d.FirstName);
            }

            return filterInDto.SortOrder == SortOrder.Descending
                ? doctors.OrderByDescending(d => EF.Property<object>(d, filterInDto.SortField.GetDisplayName()))
                : doctors.OrderBy(d => EF.Property<object>(d, filterInDto.SortField.GetDisplayName()));
        }

        public static IQueryable<Domain.Entities.Patient> PatientSorting(IQueryable<Domain.Entities.Patient> doctors, IGetPatientFindByFilterInDto filterInDto)
        {
            if (filterInDto.SortField == PatientSortField.PlotNumber)
            {
                return ApplySorting(doctors, filterInDto.SortField, filterInDto.SortOrder, d => d.Plot.Number);
            }

            if (filterInDto.SortField == PatientSortField.None)
            {
                return ApplySorting(doctors, filterInDto.SortField, filterInDto.SortOrder, d => d.FirstName);
            }

            return filterInDto.SortOrder == SortOrder.Descending
                ? doctors.OrderByDescending(d => EF.Property<object>(d, filterInDto.SortField.GetDisplayName()))
                : doctors.OrderBy(d => EF.Property<object>(d, filterInDto.SortField.GetDisplayName()));
        }
        

        private static IQueryable<T> ApplySorting<T>(IQueryable<T> source, Enum sortField, SortOrder sortOrder, Func<T, object> keySelector)
        {
            var result =sortOrder == SortOrder.Descending ? source.OrderByDescending(keySelector) : source.OrderBy(keySelector);
            return result.AsQueryable();
        }
    }
}
