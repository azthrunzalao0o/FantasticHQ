using FamilyHomeWeb.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyHomeWeb.Controllers.EntityFramework
{
    public static class ReminderDataController
    {
        public static List<Reminder> GetTodayReminders()
        {
            List<Reminder> reminders = new List<Reminder>();
            using (FantasticHQEntities context = new FantasticHQEntities())
            {
                string dayOfWeek = DateTime.Now.ToString("ddd").ToUpper();
                var query = from reminder in context.Reminders
                            where (reminder.StartDate == null || reminder.EndDate == null || (reminder.StartDate <= DateTime.Now && reminder.EndDate >= DateTime.Now))
                                && reminder.DayOfTheWeek.Contains(dayOfWeek)
                            select reminder;
                reminders = query.Distinct().ToList();
            }
            return reminders;
        }
    }
}