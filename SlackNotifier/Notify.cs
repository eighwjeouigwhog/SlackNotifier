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

    /**
	 * 通知
	 */
    public interface INotify<T>
	{
        void Push(T message);
	}
}

