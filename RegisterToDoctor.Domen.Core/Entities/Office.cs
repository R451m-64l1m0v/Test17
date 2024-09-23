﻿using RegisterToDoctor.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Domain.Core.Entities
{
    public class Office : BaseEntity
    {
        /// <summary>
        /// Номер кабинета
        /// </summary>
        public int Number {  get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
