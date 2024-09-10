using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Models.Abstractions;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class DoctorByIdResponse : РersonBase
    {
        private readonly Doctor _doctor;

        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id => _doctor.Id;

        /// <summary>
        /// Имя
        /// </summary>
        [JsonPropertyName("FirstName")]
        public string FirstName => _doctor.FirstName;

        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonPropertyName("LastName")]
        public string LastName => _doctor.LastName;

        /// <summary>
        /// Отчество
        /// </summary>
        [JsonPropertyName("MiddleName")]
        public string MiddleName => _doctor.MiddleName;

        /// <summary>
        /// Id кабинета
        /// </summary>
        [JsonPropertyName("OfficeId")]
        public Guid OfficeId => _doctor.OfficeId;

        /// <summary>
        /// Id специальности
        /// </summary>
        [JsonPropertyName("SpecializationId")]
        public Guid SpecializationId => _doctor.SpecializationId;

        /// <summary>
        /// Id участка
        /// </summary>
        [JsonPropertyName("PlotId")]
        public Guid PlotId => _doctor.PlotId;

        public DoctorByIdResponse(Doctor doctor)
        {
            _doctor = doctor;
        }

        public static DoctorByIdResponse Create(Doctor doctor) => new DoctorByIdResponse(doctor);
    }
}
