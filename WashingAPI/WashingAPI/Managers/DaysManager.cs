using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.Models;
using WashingAPI.DBModels;

namespace WashingAPI.Managers
{
    public class DaysManager
    {
        private static List<Models.Day> days = new List<Models.Day>()
        {
            new Models.Day(){Date="04-05-2022"},
            new Models.Day(){Date="05-05-2022"},
            new Models.Day(){Date="06-05-2022"},
            new Models.Day(){Date="07-05-2022"},
        };

        private Sem3Context _context = new();

        public List<Models.Day> GetAllDays()
        {
            return new(days);
        }

        public Models.Day? GetDay(string Date)
        {
            return days.FirstOrDefault((d) => d.Date == Date);
        }

        public void BookTime(string Date, string Time, string Room)
        {
            var day = GetDay(Date);
            if (!(day.Timeslots[Time] == null)) throw new ArgumentException();
            day.Timeslots[Time] = Room;
        }

        public void AddDay(string date)
        {
            _context.ChangeTracker.Clear();
            DBModels.Day day = new() { ResDate = date};
            _context.Days.Add(day);
            _context.SaveChanges();
            FillTimeslots(date);
        }

        private void FillTimeslots(string date)
        {
            int id = _context.Days.FirstOrDefault((d) => d.ResDate == date).Id;
            List<Timeslot> timeslots = new()
            {
                new Timeslot() { DayId = id, ResTime = "7:30-9:00" },
                new Timeslot() { DayId = id, ResTime = "9:00-10:30" },
                new Timeslot() { DayId = id, ResTime = "10:30-12:00" },
                new Timeslot() { DayId = id, ResTime = "12:00-13:30" },
                new Timeslot() { DayId = id, ResTime = "13:30-15:00" },
                new Timeslot() { DayId = id, ResTime = "16:30-16:30" },
                new Timeslot() { DayId = id, ResTime = "16:30-18:00" },
                new Timeslot() { DayId = id, ResTime = "18:00-19:30" },
                new Timeslot() { DayId = id, ResTime = "19:30-21:00" },
            };
            foreach (var timeslot in timeslots)
            {
                _context.Timeslots.Add(timeslot);
            }
            _context.SaveChanges(true);
        }
    }
}
