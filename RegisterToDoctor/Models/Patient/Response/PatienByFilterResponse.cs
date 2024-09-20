using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Domen.Core.Enums;
using RegisterToDoctor.Models.Abstractions;
using RegisterToDoctor.Models.Doctors.Response;
using System.Numerics;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Patient.Response
{
    public class PatienByFilterResponse
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
        [JsonPropertyName("OmsNumber")]
        public string OmsNumber { get; private set; }

        /// <summary>
        /// Номер дмс
        /// </summary>
        [JsonPropertyName("DmsNumber")]
        public string? DmsNumber { get; private set; }

        /// <summary>
        /// Участок
        /// </summary>
        [JsonPropertyName("NumberPlot")]
        public int NumberPlot { get; private set; }

        // <summary>
        /// Дата обновления
        /// </summary>
        [JsonPropertyName("UpdatedAt")]
        public DateTime? UpdatedAt { get; private set; }

        public static PatienByFilterResponse CreateResponse(Domen.Core.Entities.Patient patient) => new PatienByFilterResponse 
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
