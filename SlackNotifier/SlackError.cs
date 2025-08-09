namespace Slack
{
    /// <summary>
    /// 結果
    /// </summary>
    public class Result
    {
        public bool ok { get; set; }
        public string ts { get; set; }
    }

    /// <summary>
    /// エラー結果
    /// </summary>
    public class Error : Result
    {
        public string error { get; set; }
    }
}
