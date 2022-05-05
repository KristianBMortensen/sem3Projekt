using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.Models;

namespace WashingAPI.Managers
{
    public class DaysManager
    {
        private List<Day> days = new List<Day>()
        {
            new Day(){Date="04-05-2022"},
            new Day(){Date="05-05-2022"},
            new Day(){Date="06-05-2022"},
            new Day(){Date="07-05-2022"},
        };

        public List<Day> GetAllDays()
        {
            return new(days);
        }

        public Day GetDay(string Date)
        {
            return days.FirstOrDefault((d) => d.Date == Date);
        }

        public void DeleteDay(string Date)
        {

        }

        public void AddDay(string Date)
        {
            
        }

        public void BookTime(string Date, string Time, string Room)
        {
            var day = GetDay(Date);
            if (!(day.Timeslots[Time] == null)) throw new ArgumentException();
            day.Timeslots[Time] = Room;
        }

        public void RemoveBooking(string Date, string Time)
        {

        }


    }
}
