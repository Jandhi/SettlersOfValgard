namespace SettlersOfValgard.Model.Time
{
    public class Date
    {
        public static readonly int DaysInWeek = 10;
        public static readonly int WeeksInSeason = 5;
        public static readonly int SeasonsInYear = 4;
        public static readonly int DaysInYear = DaysInWeek * WeeksInSeason * SeasonsInYear;

        public Date(int daysSinceSettlement)
        {
            DaysSinceSettlement = daysSinceSettlement;
        }

        public int DaysSinceSettlement { get; set; }

        public void Increment()
        {
            DaysSinceSettlement++;
        }

        public static int DaysToYears(int days)
        {
            return days / DaysInYear;
        }

        public static int AgeInDays(IDated dated, Settlement settlement)
        {
            return settlement.TodaysDate.DaysSinceSettlement - dated.Birthday.DaysSinceSettlement;
        }
    }
}