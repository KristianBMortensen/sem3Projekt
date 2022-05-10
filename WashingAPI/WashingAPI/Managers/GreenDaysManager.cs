using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashingAPI.Managers
{
    public class GreenDaysManager
    {
        private static DateTime lastAction = DateTime.Parse("1 Jan 1970 00:00:00");

        public bool GetAction()
        {
            TimeSpan duration = DateTime.Now - lastAction;
            if (duration.Seconds > 30)
                return false;
            else return true;
        }

        public void UpdateLastAction()
        {
            lastAction = DateTime.Now;
        }
    }
}
