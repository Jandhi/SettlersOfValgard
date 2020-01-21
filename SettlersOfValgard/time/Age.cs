namespace SettlersOfValgard.time
{
    public class Age
    {
        
        public int Days { get; set; }
        private int birthday;
        
        public Age()
        {
            birthday = Time.Days;
            Days = 0;
        }

        public Age(int years)
        {
            birthday = Random.Next(Time.DaysInYear);
            Days = years * Time.DaysInYear + birthday;
        }

        public Age(int years, int birthday)
        {
            this.birthday = birthday;
            Days = years * Time.DaysInYear + birthday;
        }

        public void doAging()
        {
            Days++;
        }

        public bool IsBirthday()
        {
            return Time.Days == birthday;
        }
    }
}