﻿using Microsoft.AspNetCore.Mvc;
using RegisterToDoctor.Domen.Core.Common;
using RegisterToDoctor.Models.Enum;

namespace RegisterToDoctor.Models.Doctors.Request
{
    public class DoctorByFilterRequest
    {

        /// <summary>
        /// Сортировачное поле
        /// </summary>
        [FromQuery]
        public DoctorSortField SortField { get; set; }

        /// <summary>
        /// Упорядочить
        /// </summary>
        [FromQuery]
        public bool Ascending {  get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>
        [FromQuery]
        public int PageNumber { get; set; }

        /// <summary>
        /// Количество записей на странице
        /// </summary>
        [FromQuery]
        public int PageSize { get; set; }
    }
}
