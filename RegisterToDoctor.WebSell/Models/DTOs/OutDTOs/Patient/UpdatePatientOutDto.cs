﻿using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;
using System.Text.Json.Serialization;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Patient
{
    public class UpdatePatientOutDto : IResponseIdOutDto
    {
        /// <summary>
        /// Id пациента
        /// </summary>
        [JsonPropertyName("PatientId")]
        public Guid Id { get; private set; }

        public static UpdatePatientOutDto CreateResponse(Domain.Entities.Patient patient) =>
            new UpdatePatientOutDto { Id = patient.Id };
    }
}
