// The idea of this library is based on a post by 'Federico Alterio' here:
// https://www.codeproject.com/Tips/5367698/Awaiting-a-Tuple-in-Csharp

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EasyAsync
{
    public static class AwaitTupleExtensions
    {
        public static TaskAwaiter<(T1, T2)> GetAwaiter<T1, T2>(this (Task<T1>, Task<T2>) tuple)
        {
            async Task<(T1, T2)> UnifyTasks()
            {
                var (task1, task2) = tuple;
                await Task.WhenAll(task1, task2);
                return (task1.Result, task2.Result);
            }

            return UnifyTasks().GetAwaiter();
        }

        public static TaskAwaiter<(T1, T2, T3)> GetAwaiter<T1, T2, T3>(this (Task<T1>, Task<T2>, Task<T3>) tuple)
        {
            async Task<(T1, T2, T3)> UnifyTasks()
            {
                var (task1, task2, task3) = tuple;
                await Task.WhenAll(task1, task2, task3);
                return (task1.Result, task2.Result, task3.Result);
            }

            return UnifyTasks().GetAwaiter();
        }

        public static TaskAwaiter<(T1, T2, T3, T4)> GetAwaiter<T1, T2, T3, T4>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>) tuple)
        {
            async Task<(T1, T2, T3, T4)> UnifyTasks()
            {
                var (task1, task2, task3, task4) = tuple;
                await Task.WhenAll(task1, task2, task3, task4);
                return (task1.Result, task2.Result, task3.Result, task4.Result);
            }
            
            return UnifyTasks().GetAwaiter();
        }

        public static TaskAwaiter<(T1, T2, T3, T4, T5)> GetAwaiter<T1, T2, T3, T4, T5>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>) tuple)
        {
            async Task<(T1, T2, T3, T4, T5)> UnifyTasks()
            {
                var (task1, task2, task3, task4, task5) = tuple;
                await Task.WhenAll(task1, task2, task3, task4, task5);
                return (task1.Result, task2.Result, task3.Result, task4.Result, task5.Result);
            }
            
            return UnifyTasks().GetAwaiter();
        }

        public static TaskAwaiter<(T1, T2, T3, T4, T5, T6)> GetAwaiter<T1, T2, T3, T4, T5, T6>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>) tuple)
        {
            async Task<(T1, T2, T3, T4, T5, T6)> UnifyTasks()
            {
                var (task1, task2, task3, task4, task5, task6) = tuple;
                await Task.WhenAll(task1, task2, task3, task4, task5, task6);
                return (task1.Result, task2.Result, task3.Result, task4.Result, task5.Result, task6.Result);
            }

            return UnifyTasks().GetAwaiter();
        }


    }
}
