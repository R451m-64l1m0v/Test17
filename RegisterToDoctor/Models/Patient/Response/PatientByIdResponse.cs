using RegisterToDoctor.Domen.Core.Enums;
using RegisterToDoctor.Models.Abstractions;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Patient.Response
{
    public class PatientByIdResponse
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
        /// Id участка
        /// </summary>
        [JsonPropertyName("PlotId")]
        public Guid PlotId => _patient.PlotId;

        public PatientByIdResponse(Domen.Core.Entities.Patient patient)
        {
            _patient = patient;
        }

        public static PatientByIdResponse Create(Domen.Core.Entities.Patient patient) => new PatientByIdResponse(patient);
    }
}
