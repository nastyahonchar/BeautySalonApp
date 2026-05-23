namespace BeautySalon.MAUI.Models
{
    public class EmployeeScheduleModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan WorkStart { get; set; }
        public TimeSpan WorkEnd { get; set; }
    }
}