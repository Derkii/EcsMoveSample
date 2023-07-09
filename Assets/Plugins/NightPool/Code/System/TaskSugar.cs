using System;
using System.Threading.Tasks;

namespace Plugins.NightPool.Code.System
{
    public static class TaskSugar
    {
        public static Task Delay(float time)
        {
            return Task.Delay(TimeSpan.FromSeconds(time));
        }

        public static Task Seconds(this float time)
        {
            return Task.Delay(TimeSpan.FromSeconds(time));
        }
    }
}