using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyAsync
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Safely forget about a task when you do not want to await for it.
        /// Although you don't want to await, but you can still handle its exceptions by setting its <param name="onException"></param>
        /// </summary>
        /// <param name="task"></param>
        /// <param name="onException"></param>
        /// <param name="cancellationToken"></param>
        public static void Forget(this Task task, Action? onException = null, CancellationToken cancellationToken = new CancellationToken())
        {
            if (onException != null)
            {
                task.ContinueWith(t =>
                    {
                        onException();
                    },
                    cancellationToken: cancellationToken,
                    TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Current
                );
            }
        }
    }
}
