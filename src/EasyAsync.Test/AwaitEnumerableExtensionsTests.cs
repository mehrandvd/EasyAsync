using EasyAsync;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyAsync.Test
{
    public class AwaitEnumerableExtensionsTests
    {
        [Fact]
        public async Task AwaitEnumerableT_MustWork()
        {
            var tasks = new List<Task<int>>() { GetAsync(0), GetAsync(1) };
            var results = await tasks;

            Assert.Equal(0, results[0]);
            Assert.Equal(1, results[1]);
        }

        [Fact]
        public async Task AwaitEnumerable_MustWork()
        {
            List<Task> tasks = new List<Task>() { Task.Delay(1000), Task.Delay(500) };
            await tasks;
        }

        private async Task<T> GetAsync<T>(T returnValue)
        {
            await Task.Delay(10);
            return returnValue;
        }
    }
}