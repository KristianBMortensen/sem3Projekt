using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingAPI.Managers
{
    public class GreenDaysManager
    {
        private static DateTime lastAction = DateTime.Parse("1 Jan 1970 00:00:00");
        private static bool start = false;
        private static DateTime startTime = DateTime.Parse("1 Jan 1970 00:00:00");

        public KeyValuePair<bool, string> GetAction()
        {
            TimeSpan duration = DateTime.UtcNow - lastAction;
            if (duration.Seconds > 30)
            {
                start = false;
                return new KeyValuePair<bool, string>(false, startTime.ToString("HH:mm:ss"));
            }
            else
            {                
                if (!start)
                    startTime = DateTime.UtcNow;
                start = true;
                DateTime future = startTime;
                future = future.AddMinutes(90);
                TimeSpan timeLeft = future - DateTime.UtcNow;
                return new KeyValuePair<bool, string>(true, timeLeft.Hours+":"+timeLeft.Minutes+":"+timeLeft.Seconds);
            }
        }

        public void UpdateLastAction()
        {
            lastAction = DateTime.Now;
        }
    }
}
