using System.Text.Json.Serialization;
using RegisterToDoctor.Domain.Enums;
using RegisterToDoctor.WebSell.Interfaces;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Patient
{
    public class PatientByIdOutDto : ICreatePatient
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatienId")]
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
        /// Дата рождения
        /// </summary>
        [JsonPropertyName("DateOfBirth")]
        public DateTime DateOfBirth { get; private set; }

        /// <summary>
        /// Адресс
        /// </summary>
        [JsonPropertyName("Address")]
        public string Address { get; private set; }

        /// <summary>
        /// Пол
        /// </summary>
        [JsonPropertyName("Gender")]
        public Gender Gender { get; private set; }

        /// <summary>
        /// Номер омс
        /// </summary>
        [JsonPropertyName("OmsNumder")]
        public string OmsNumber { get; private set; }

        /// <summary>
        /// Номер дмс
        /// </summary>
        [JsonPropertyName("OmsNumder")]
        public string? DmsNumber { get; private set; }

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

        public static PatientByIdOutDto CreateResponse(Domain.Entities.Patient patient) => new PatientByIdOutDto
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
