using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DAL.Entities
{
    public class EmployeeService
    {
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }

        public Employee Employee { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}
