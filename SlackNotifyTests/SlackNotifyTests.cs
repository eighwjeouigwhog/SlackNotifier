using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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
            var slack = new Slack.BotNotifier(token);
            return slack;
        }

        [TestMethod()]
        public void PushTest()
        {
            var slack = GetSlack();
            var p = new Payload() { channel="#test", username="Tester", text = "test"};
            slack.Push(p);
        }
    }
}