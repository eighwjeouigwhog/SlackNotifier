using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace tverrist.Tests
{
    [TestClass()]
    public class RateLimitcsTests
    {
        [TestMethod()]
        public void InvokeTest()
        {

            var sw = new Stopwatch();

            sw.Start();

            var rl = new Slack.RateLimit(1000);

            rl.Invoke();
            rl.Invoke();
            rl.Invoke();
            rl.Invoke();
            rl.Invoke();


            var time = sw.Elapsed.TotalSeconds;
            Console.WriteLine($"経過時間: {time}s");
            Assert.IsTrue( time >= 5);

        }
    }
}