namespace BeautySalon.DAL.Entities
{
    public class EmployeeSchedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan WorkStart { get; set; }
        public TimeSpan WorkEnd { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}