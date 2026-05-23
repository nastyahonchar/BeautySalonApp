namespace BeautySalon.BLL.DTOs.EmployeeSchedules
{
    public class EmployeeScheduleDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan WorkStart { get; set; }
        public TimeSpan WorkEnd { get; set; }
    }
}