﻿using System.Text.Json.Serialization;
using RegisterToDoctor.WebSell.Interfaces.IDTOs.IOutDTOs;

namespace RegisterToDoctor.WebSell.Models.DTOs.OutDTOs.Doctor
{
    public class CreateDoctorOutDto : IResponseIdOutDto
    {
        /// <summary>
        /// Id доктора
        /// </summary>
        [JsonPropertyName("DoctorId")]
        public Guid Id { get; private set; }

        public static CreateDoctorOutDto CreateResponse(Domain.Entities.Doctor doctor) =>
            new CreateDoctorOutDto { Id = doctor.Id };
    }
}
