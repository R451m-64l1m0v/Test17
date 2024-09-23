using System.Text.Json.Serialization;
using RegisterToDoctor.Domain.Entities;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class DoctorByIdResponse
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id { get; private set; }

        /// <summary>
        /// Имя
        /// </summary>
        [JsonPropertyName("FirstName")]
        public string FirstName { get; private set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonPropertyName("LastName")]
        public string LastName { get; private set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [JsonPropertyName("MiddleName")]
        public string? MiddleName { get; private set; }

        /// <summary>
        /// Id кабинета
        /// </summary>
        [JsonPropertyName("OfficeId")]
        public Guid OfficeId { get; private set; }

        /// <summary>
        /// Id специальности
        /// </summary>
        [JsonPropertyName("SpecializationId")]
        public Guid SpecializationId { get; private set; }

        /// <summary>
        /// Id участка
        /// </summary>
        [JsonPropertyName("PlotId")]
        public Guid PlotId { get; private set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        [JsonPropertyName("UpdatedAt")]
        public DateTime? UpdatedAt { get; private set; }

        public static DoctorByIdResponse CreateResponse(Doctor doctor) => new DoctorByIdResponse
        {
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            MiddleName = doctor.MiddleName,
            OfficeId = doctor.OfficeId,
            SpecializationId = doctor.SpecializationId,
            PlotId = doctor.PlotId,
            UpdatedAt = doctor.UpdatedAt,
        };
    }
}
