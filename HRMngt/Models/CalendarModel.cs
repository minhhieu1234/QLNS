using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMngt.Models
{
    public class CalendarModel
    {
        private string userId;
        private DateTime? date;
        private DateTime? checkIn;
        private DateTime? checkOut;
        private DateTime? realCheckIn;
        private DateTime? realCheckOut;
        private string status;

        // Encapsulate fields
        public string UserId { get => userId; set => userId = value; }
        public DateTime? Date { get => date; set => date = value; }
        public DateTime? CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime? CheckOut { get => checkOut; set => checkOut = value; }
        public DateTime? RealCheckIn { get => realCheckIn; set => realCheckIn = value; }
        public DateTime? RealCheckOut { get => realCheckOut; set => realCheckOut = value; }
        public string Status { get => status; set => status = value; }
    }
}
