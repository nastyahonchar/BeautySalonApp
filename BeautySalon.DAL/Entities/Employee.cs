using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Position { get; set; } = null!;
        public bool IsActive { get; set; }

        public ICollection<EmployeeService> EmployeeServices { get; set; } = new List<EmployeeService>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
