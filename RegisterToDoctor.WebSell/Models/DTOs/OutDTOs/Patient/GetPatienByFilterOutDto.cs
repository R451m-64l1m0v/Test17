using System.Text.Json.Serialization;
using RegisterToDoctor.Domain.Enums;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Patient
{
    public class GetPatienByFilterOutDto : IGetPatienByFilterOutDto
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatienId")]
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
        /// Дата рождения
        /// </summary>
        [JsonPropertyName("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Адресс
        /// </summary>
        [JsonPropertyName("Address")]
        public string Address { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [JsonPropertyName("Gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Номер омс
        /// </summary>
        [JsonPropertyName("OmsNumber")]
        public string OmsNumber { get; set; }

        /// <summary>
        /// Номер дмс
        /// </summary>
        [JsonPropertyName("DmsNumber")]
        public string? DmsNumber { get; set; }

        /// <summary>
        /// Участок
        /// </summary>
        [JsonPropertyName("NumberPlot")]
        public int NumberPlot { get; set; }

        // <summary>
        /// Дата обновления
        /// </summary>
        [JsonPropertyName("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        public static GetPatienByFilterOutDto Create(Domain.Entities.Patient patient) => new GetPatienByFilterOutDto
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
            NumberPlot = patient.Plot.Number,
            UpdatedAt = patient.UpdatedAt,
        };
    }
}
