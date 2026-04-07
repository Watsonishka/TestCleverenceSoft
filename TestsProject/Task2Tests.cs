using Task2ConsoleApp;

namespace TestsProject
{
    public class Task2Tests
    {
        [Fact]
        public void SingleThread_AddToCount_WorksCorrectly()
        {
            Server.Reset();
            Server.AddToCount(5);
            Server.AddToCount(3);
            Assert.Equal(8, Server.GetCount());
        }
        [Fact]
        public void MultipleThreads_AddToCount_NoDataRace()
        {
            Server.Reset();
            var threadsCount = 100;
            var incrementsPerThread = 1000;
            var tasks = new Task[threadsCount];

            for (var i = 0; i < threadsCount; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    for (var j = 0; j < incrementsPerThread; j++)
                    {
                        Server.AddToCount(1);
                    }
                });
            }
            Task.WaitAll(tasks);
            int expected = threadsCount * incrementsPerThread;
            Assert.Equal(expected, Server.GetCount());
        }
        [Fact]
        public void MultipleReaders_CanReadSimultaneously()
        {
            Server.Reset();
            var startTime = DateTime.Now;
            var tasks = new Task[10];

            for (var i = 0; i < 10; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    Thread.Sleep(100);
                    return Server.GetCount();
                });
            }

            Task.WaitAll(tasks);
            var duration = (DateTime.Now - startTime).TotalMilliseconds;
            Assert.True(duration < 500);
        }
    }
}
