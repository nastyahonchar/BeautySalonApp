namespace BeautySalon.MAUI.Models
{
    public static class UserSession
    {
        public static int ClientId { get; set; }
        public static string FirstName { get; set; } = "";
        public static string LastName { get; set; } = "";
        public static string Email { get; set; } = "";
        public static string PhoneNumber { get; set; } = "";

        public static string FullName => $"{FirstName} {LastName}";

        public static void Clear()
        {
            ClientId = 0;
            FirstName = "";
            LastName = "";
            Email = "";
            PhoneNumber = "";
        }
    }
}