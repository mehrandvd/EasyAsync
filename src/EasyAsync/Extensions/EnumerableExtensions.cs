// The idea of this library is based on a post by 'Federico Alterio' here:
// https://www.codeproject.com/Tips/5367698/Awaiting-a-Tuple-in-Csharp

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EasyAsync
{
    public static class AwaitEnumerableExtensions
    {
        public static TaskAwaiter<T[]> GetAwaiter<T>(this IEnumerable<Task<T>> tasks)
        { 
            return Task.WhenAll(tasks).GetAwaiter();
        }

        public static TaskAwaiter GetAwaiter(this IEnumerable<Task> tasks)
        {
            return Task.WhenAll(tasks).GetAwaiter();
        }

    }
}
