using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.MAUI.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Position { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
