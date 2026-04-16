using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.BLL.DTOs.Appointments
{
    public class UpdateAppointmentDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }

        public DateTime StartTime { get; set; }

        public string Status { get; set; } = null!;
    }
}
