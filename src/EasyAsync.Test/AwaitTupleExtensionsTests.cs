namespace EasyAsync.Test
{
    public class AwaitTupleExtensionsTests
    {
        [Fact]
        public async Task AwaitTuple2_MustWork()
        {
            var (number, text) = await (GetAsync(1), GetAsync("Text"));

            Assert.Equal(1, number);
            Assert.Equal("Text", text);
        }

        [Fact]
        public async Task AwaitTuple3_MustWork()
        {
            var (number1, text2, text3) = await (GetAsync(1), GetAsync("Text2"), GetAsync("Text3"));

            Assert.Equal(1, number1);
            Assert.Equal("Text2", text2);
            Assert.Equal("Text3", text3);
        }

        [Fact]
        public async Task AwaitTuple4_MustWork()
        {
            var (number1, text2, text3, number4) = await (GetAsync(1), GetAsync("Text2"), GetAsync("Text3"), GetAsync(4));

            Assert.Equal(1, number1);
            Assert.Equal("Text2", text2);
            Assert.Equal("Text3", text3);
            Assert.Equal(4, number4);

        }

        [Fact]
        public async Task AwaitTuple5_MustWork()
        {
            var (number1, text2, text3, number4, number5) = await (GetAsync(1), GetAsync("Text2"), GetAsync("Text3"), GetAsync(4), GetAsync(5));

            Assert.Equal(1, number1);
            Assert.Equal("Text2", text2);
            Assert.Equal("Text3", text3);
            Assert.Equal(4, number4);
            Assert.Equal(5, number5);
        }

        [Fact]
        public async Task AwaitTuple6_MustWork()
        {
            var (number1, text2, text3, number4, number5, text6) = await (GetAsync(1), GetAsync("Text2"), GetAsync("Text3"), GetAsync(4), GetAsync(5), GetAsync("Text6"));

            Assert.Equal(1, number1);
            Assert.Equal("Text2", text2);
            Assert.Equal("Text3", text3);
            Assert.Equal(4, number4);
            Assert.Equal(5, number5);
            Assert.Equal("Text6", text6);
        }

        private async Task<T> GetAsync<T>(T returnValue)
        {
            await Task.Delay(1000);
            return returnValue;
        }
    }
}