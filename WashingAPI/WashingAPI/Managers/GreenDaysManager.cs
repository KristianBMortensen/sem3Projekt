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
            TimeSpan duration = DateTime.Now - lastAction;
            if (duration.Seconds > 30)
            {
                start = false;
                return new KeyValuePair<bool, string>(false, startTime.ToString("h:m:s"));
            }
            else
            {                
                if (!start)
                    startTime = DateTime.Now;
                start = true;
                return new KeyValuePair<bool, string>(true, startTime.ToString("HH:mm:ss"));
            }
        }

        public void UpdateLastAction()
        {
            lastAction = DateTime.Now;
        }
    }
}
