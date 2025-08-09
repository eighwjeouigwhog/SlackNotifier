namespace Notify
{

    public enum Priority
    {
        VeryLow = -2,
        Moderate = -1,
        Warn = -1,
        Normal = 0,
        Error = 1,
        High = 1,
        Emergency = 2
    }

    /// <summary>
    /// 通知インターフェース
    /// </summary>
    /// <typeparam name="T">メッセージ</typeparam>
    /// <typeparam name="S">結果</typeparam>
    public interface INotify<T,S>
	{
        S Push(T message);
	}
}

