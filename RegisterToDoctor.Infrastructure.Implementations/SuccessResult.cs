using RegisterToDoctor.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterToDoctor.Infrastructure.Implementations
{
    internal class SuccessResult<TResult> : ISuccessResult<TResult> where TResult : class
    {
        public SuccessResult(bool isSuccess, TResult? result = null)
        {
            IsSuccess = isSuccess;
            Result = result;
        }
        public bool IsSuccess { get; }

        public TResult? Result { get; }
    }
}
