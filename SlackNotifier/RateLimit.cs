using System.Diagnostics;
using System.Threading;

namespace Slack
{
    public class RateLimit
    {
        /// <summary>
        /// ms
        /// </summary>
        long Loose;

        int RequestCnt = 0;

        Stopwatch SW = new Stopwatch();

        long LastFired;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loose">ms</param>
        public RateLimit(long loose)
        {
            Loose = loose;
        }

        public void Invoke()
        {
            SW.Stop();

            //全体の経過時間
            var elapsed = SW.ElapsedMilliseconds;


            SW.Start();


            Debug.WriteLine($"全体経過時間: {elapsed}");
            Debug.WriteLine($"前回の経過時間: {LastFired}");

            Debug.WriteLine($"前回からの経過時間: {elapsed - LastFired}");

            long waitTime = 0;

            //前回からの経過時間を考慮
            waitTime = Loose - (elapsed - LastFired);


            //指定時間に足りない分待つ
            if (waitTime > 0)
            {
                //wait 
                Debug.WriteLine($"待つ: {waitTime} ms");
                Thread.Sleep((int)waitTime);
                //今回の実行時間
                LastFired = elapsed + waitTime;
            }
            else
            {
                //今回の実行時間
                LastFired = elapsed;
            }




        }

    }
}
