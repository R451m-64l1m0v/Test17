using RegisterToDoctor.Domen.Core.Entities;
using RegisterToDoctor.Domen.Core.Enums;
using RegisterToDoctor.Models.Abstractions;
using RegisterToDoctor.Models.Doctors.Response;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Patient.Response
{
    public class PatienByFilterResponse
    {
        private readonly Domen.Core.Entities.Patient _patient;

        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatienId")]
        public Guid Id => _patient.Id;

        /// <summary>
        /// Имя
        /// </summary>
        [JsonPropertyName("FirstName")]
        public string FirstName => _patient.FirstName;

        /// <summary>
        /// Фамилия
        /// </summary>
        [JsonPropertyName("LastName")]
        public string LastName => _patient.LastName;

        /// <summary>
        /// Отчество
        /// </summary>
        [JsonPropertyName("MiddleName")]
        public string MiddleName => _patient.MiddleName;

        /// <summary>
        /// Дата рождения
        /// </summary>
        [JsonPropertyName("DateOfBirth")]
        public DateTime DateOfBirth => _patient.DateOfBirth;

        /// <summary>
        /// Адресс
        /// </summary>
        [JsonPropertyName("Address")]
        public string Address => _patient.Address;

        /// <summary>
        /// Пол
        /// </summary>
        [JsonPropertyName("Gender")]
        public Gender Gender => _patient.Gender;

        /// <summary>
        /// Участок
        /// </summary>
        [JsonPropertyName("NumberPlot")]
        public int NumberPlot => _patient.Plot.Number;

        public PatienByFilterResponse(Domen.Core.Entities.Patient patient)
        {
            _patient = patient;
        }

        public static PatienByFilterResponse Create(Domen.Core.Entities.Patient patient) => new PatienByFilterResponse(patient);
    }
}
