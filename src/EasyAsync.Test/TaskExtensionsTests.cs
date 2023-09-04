using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAsync.Test
{
    public class TaskExtensionsTests
    {
        [Fact]
        public async Task Forget_MustWork()
        {
            GetSampleAsync(1).Forget();
        }

        [Fact]
        public async Task Forget_WithException_MustWork()
        {
            var isThrown = false;
            ThrowAsync(1).Forget(onException: ()=>
            {
                isThrown = true;
            });

            await Task.Delay(TimeSpan.FromSeconds(2));

            Assert.True(isThrown);
        }

        [Fact]
        public async Task Forget_WithCancellation_MustWork()
        {
            var isThrown = false;
            var cts = new CancellationTokenSource();

            ThrowAsync(2).Forget(onException: () =>
            {
                isThrown = true;
            }, cancellationToken: cts.Token);

            await Task.Delay(TimeSpan.FromSeconds(1));

            cts.Cancel();

            await Task.Delay(TimeSpan.FromSeconds(2));


            Assert.False(isThrown);
        }

        private async Task GetSampleAsync(int seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
        }

        private async Task ThrowAsync(int seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            throw new Exception("ERROR");
        }
    }
}
