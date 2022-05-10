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

        public List<Day> GetAllDays()
        {
            var days = _context.Days.AsNoTracking().Include((d) => d.Timeslots).ToList();
            return days;
        }

        public Day? GetDay(string Date)
        {
            return _context.Days.AsNoTracking().Include((d) => d.Timeslots).FirstOrDefault((d) => d.ResDate == Date);
        }

        public void BookTime(int TimeslotID, string loginId)
        {
            string Room = _context.Logins.Find(loginId).Room;
            _context.Timeslots.Find(TimeslotID).RoomNo = Room;
            _context.SaveChanges();
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
