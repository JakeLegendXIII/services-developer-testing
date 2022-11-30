
namespace Utils;

public class DateUtilities
{
    public bool IsWeekend(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;
    }

    public bool IsWeekDay(DateTime date)
    {
        return !IsWeekDay(date);
    }
}
