namespace Slack
{
    public class Result
    {
        public bool ok { get; set; }
        public string ts { get; set; }
    }

    public class Error : Result
    {
        public string error { get; set; }
    }
}
