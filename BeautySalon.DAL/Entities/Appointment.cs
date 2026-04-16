using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DAL.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Status { get; set; } = null!;
        public decimal TotalPrice { get; set; }

        public Client Client { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}
