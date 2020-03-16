using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Time;

namespace SettlersOfValgard.Model.Varsk
{
    public class Varsk : Human
    {
        public static int VarskAdultYears = 5;
        public static int VarskElderYears = 20;
        
        public string GivenName { get; }
        public string ParentName { get; }
        private string NameSpace => ParentName.Length > 0 ? " " : "";
        public override string Name => $"{GivenName}{NameSpace}{ParentName}";
        public override Date Birthday { get; }
        public override int AdultYears { get; } = VarskAdultYears;
        public override int ElderYears { get; } = VarskElderYears;


        public Varsk(Date birthday, string givenName, string parentName)
        {
            Birthday = birthday;
            GivenName = givenName;
            ParentName = parentName;
        }
    }
}