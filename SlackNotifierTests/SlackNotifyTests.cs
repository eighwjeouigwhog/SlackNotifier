namespace Slack.Tests
{
    public class LoadSetting
    {
        public string BotToken { get; private set; }

        public void Load()
        {
            BotToken = File.ReadAllText("secret.txt");
        }
    }

    [TestClass()]
    public class SlackNotifyTests
    {

        public static BotNotifier GetSlack() {
            var s = new LoadSetting();
            s.Load();

            var token = s.BotToken;
            var slack = new BotNotifier(token);
            return slack;
        }
        public static BotNotifier GetInvalidSlack()
        {
            var slack = new BotNotifier("invalid token");
            return slack;
        }

        [TestMethod()]
        public void PushInvalidTest()
        {
            try
            {
                var slack = GetInvalidSlack();
                var p = new Payload() { channel = "#test", username = "Tester", text = "test" };
                slack.Push(p);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("invalid_auth"));
            }
        }

        [TestMethod()]
        public void PushTest()
        {
            var slack = GetSlack();
            var p = new Payload() { channel = "#test", username = "Tester", text = "test" };
            slack.Push(p);
        }

        [TestMethod()]
        public void PushThreadTest()
        {
            var slack = GetSlack();
            var p = new Payload() { channel = "#test", username = "Tester", text = "test" };
            var ts = slack.Push(p).ts;

            var p2 = new Payload() { channel = "#test", username = "Tester", text = "test2", thread_ts = ts };
            slack.Push(p2);
        }
    }
}