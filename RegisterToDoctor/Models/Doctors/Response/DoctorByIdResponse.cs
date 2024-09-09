using RegisterToDoctor.Models.Abstractions;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.Models.Doctors.Response
{
    public class DoctorByIdResponse : РersonBase
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id { get; set; }

        /// <summary>
        /// Id кабинета
        /// </summary>
        [JsonPropertyName("OfficeId")]
        public Guid OfficeId { get; set; }

        /// <summary>
        /// Id специальности
        /// </summary>
        [JsonPropertyName("SpecializationId")]
        public Guid SpecializationId { get; set; }

        /// <summary>
        /// Id участка
        /// </summary>
        [JsonPropertyName("PlotId")]
        public Guid PlotId { get; set; }
    }
}
