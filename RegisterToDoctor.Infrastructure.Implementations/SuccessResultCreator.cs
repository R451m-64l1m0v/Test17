using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegisterToDoctor.Infrastructure.Abstractions;

namespace RegisterToDoctor.Infrastructure.Implementations
{
    public static class SuccessResultCreator 
    {
        public static ISuccessResult<TResult> Create<TResult>(bool isSuccess, TResult? result) where TResult : class
        {
            return new SuccessResult<TResult>(isSuccess, result);
        }

        public static ISuccessResult<TResult> Create<TResult>(TResult? result) where TResult : class
        {
            return new SuccessResult<TResult>(result != null, result);
        }
    }
}
