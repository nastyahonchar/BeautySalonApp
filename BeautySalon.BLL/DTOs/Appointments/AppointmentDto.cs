using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.DTOs.Appointments
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Status { get; set; } = null!;
        public decimal TotalPrice { get; set; }
    }
}
