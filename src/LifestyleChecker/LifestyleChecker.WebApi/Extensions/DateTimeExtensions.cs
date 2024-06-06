namespace LifestyleChecker.WebApi.Extensions
{
    public static class DateTimeExtensions
    {
        public static int Age(this DateTime sender)
        {
            var today = DateTime.Today;
            var age = today.Year - sender.Year;
            if (sender.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
