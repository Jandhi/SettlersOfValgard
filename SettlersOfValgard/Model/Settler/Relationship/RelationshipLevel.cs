using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public class RelationshipLevel : CustomEnum
    {
        public static readonly RelationshipLevel Hate = new RelationshipLevel("Hate", -2, CustomConsole.Red);
        public static readonly RelationshipLevel Dislike = new RelationshipLevel("Dislike", -1, CustomConsole.Cyan);
        public static readonly RelationshipLevel Neutral = new RelationshipLevel("Neutral", 0, CustomConsole.Yellow);
        public static readonly RelationshipLevel Like = new RelationshipLevel("Like", 1, CustomConsole.Green);
        public static readonly RelationshipLevel Love = new RelationshipLevel("Love", 2, CustomConsole.Magenta);
        
        private RelationshipLevel(string name, int value, string color) : base(name, value, color) {}
        
        public static RelationshipLevel Get(int value)
        {
            if (value < -15)
            {
                return Hate;
            }

            if (value < -5)
            {
                return Dislike;
            }

            if (value < 5)
            {
                return Neutral;
            }

            if (value < 15)
            {
                return Like;
            }
                
            return Love;
        }
    }
}