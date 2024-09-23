using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Infrastructure.Abstractions
{
    public interface ISuccessResult<TResult> where TResult : class
    {
        /// <summary>
        /// статус опер
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// резутьтат
        /// </summary>
        TResult? Result { get; }
    }
}
