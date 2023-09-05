using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace EasyAsync.Test
{
    public class TimeoutTaskTests
    {
        [Fact]
        public async Task Timeout_MustWork()
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(1));
            var run = false;
            var sw = Stopwatch.StartNew();

            await Assert.ThrowsAsync<TaskCanceledException>(
                () => GetSampleAsync(() => { run = true; }, 2, cts.Token)
            );

            Assert.Equal(1, sw.Elapsed.Seconds);

            await Task.Delay(TimeSpan.FromSeconds(3));

            Assert.False(run);
        }

        private async Task GetSampleAsync(Action action, int seconds, CancellationToken cancellationToken = new())
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds), cancellationToken);
            action();
        }
    }
}