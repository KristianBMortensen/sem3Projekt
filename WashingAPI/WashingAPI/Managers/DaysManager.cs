using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashingAPI.DBModels;
using Microsoft.EntityFrameworkCore;

namespace WashingAPI.Managers
{
    public class DaysManager
    {
        private Sem3Context _context = new();

        public List<Day> GetAllDays(string room)
        {
            var days = _context.Days.AsNoTracking().Include((d) => d.Timeslots).ToList();
            // Checks if asked for a specific room
            if (!String.IsNullOrWhiteSpace(room))
            {
                //limit days to those where that has a timeslot that is booked by the room
                days = days.FindAll((d) => d.Timeslots.Any((t) => t.RoomNo == room));
                //Limits the timeslots to only those that are booked by the room
                foreach(var day in days)
                {
                    day.Timeslots = day.Timeslots.Where((t) => t.RoomNo == room).ToList();
                }
            }
            return days;
        }

        public Day GetDay(string Date)
        {
            var day = _context.Days.AsNoTracking().Include((d) => d.Timeslots).FirstOrDefault((d) => d.ResDate == Date);
            // if the day does not exist we create a new day
            if (day == null)
            {
                DateTime dt = DateTime.Parse(Date);
                // Checks if the day is a green day
                bool isGreenday = dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Wednesday;
                AddDay(Date, isGreenday);
                day = _context.Days.AsNoTracking().Include((d) => d.Timeslots).FirstOrDefault((d) => d.ResDate == Date);
            }
            return day;
        }

        public void BookTime(int TimeslotID, string loginId)
        {
            string Room = _context.Logins.Find(loginId).Room;
            _context.Timeslots.Find(TimeslotID).RoomNo = Room;
            _context.SaveChanges();
        }

        public void AddDay(string date, bool greenDay = false)
        {
            _context.ChangeTracker.Clear();
            Day day = new() { ResDate = date, GreenDay = greenDay};
            _context.Days.Add(day);
            _context.SaveChanges();
            // if its not a greenday we add timeslots to the day
            if (!greenDay)
            {
                FillTimeslots(date);
            }
            
        }

        public List<Day> GetWeekDay(int numdays)
        {
            List<Day> dayList = new List<Day>();
            // we remove 1 day from the datetime so that the first run of the loop returns today
            DateTime today = DateTime.Now.AddDays(-1);
            for (var i = 0; i < numdays; i++)
            {
                today = today.AddDays(1);
                string todayS = today.ToString("dd-MM-yyyy");
                //changes the format from DD.MM.YYYY to DD-MM-YYYY that is our chosen date format
                todayS = todayS.Replace(".", "-");
                // we use Getday so that if the day does not exist it will be added
                dayList.Add(GetDay(todayS));
            }
            return dayList;
        }

        public void DeleteBooking(int TimeslotId)
        {
            _context.Timeslots.Find(TimeslotId).RoomNo = null;
            _context.SaveChanges();
        }

        private void FillTimeslots(string date)
        {
            // gets the dayId for timeslots
            int id = _context.Days.FirstOrDefault((d) => d.ResDate == date).Id;
            // yeah this is a mess but unless the user wants to manualy add the timeslots ¯\_(ツ)_/¯
            List<Timeslot> timeslots = new()
            {
                new Timeslot() { DayId = id, ResTime = "7:30-9:00" },
                new Timeslot() { DayId = id, ResTime = "9:00-10:30" },
                new Timeslot() { DayId = id, ResTime = "10:30-12:00" },
                new Timeslot() { DayId = id, ResTime = "12:00-13:30" },
                new Timeslot() { DayId = id, ResTime = "13:30-15:00" },
                new Timeslot() { DayId = id, ResTime = "15:00-16:30" },
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
