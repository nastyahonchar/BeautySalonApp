using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DAL.Entities
{
    public class Service
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }

        public Category Category { get; set; } = null!;
        public ICollection<EmployeeService> EmployeeServices { get; set; } = new List<EmployeeService>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
