using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Doctor
{
    public class GetDoctorFindByFilterOutDto : IGetDoctorFindByFilterOutDto
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [JsonPropertyName("MiddleName")]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Номер кабинета
        /// </summary>
        [JsonPropertyName("NumberOffice")]
        public int NumberOffice { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        [JsonPropertyName("SpecializationName")]
        public string Specialization { get; set; }

        /// <summary>
        /// Номер участка
        /// </summary>
        [JsonPropertyName("NumberPlot")]
        public int NumberPlot { get; set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        [JsonPropertyName("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        public static GetDoctorFindByFilterOutDto Create(Domain.Entities.Doctor doctor) => new GetDoctorFindByFilterOutDto
        {
            Id = doctor.Id,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            MiddleName = doctor.MiddleName,
            NumberOffice = doctor.Office.Number,
            Specialization = doctor.Specialization.Name,
            NumberPlot = doctor.Plot.Number,
            UpdatedAt = doctor.UpdatedAt,
        };
    }
}
