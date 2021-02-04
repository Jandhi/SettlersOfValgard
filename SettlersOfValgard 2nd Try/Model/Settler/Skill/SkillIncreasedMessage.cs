using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Message;

namespace SettlersOfValgard.Model.Settler.Skill
{
    public class SkillIncreasedMessage : Model.Message.Message
    {
        public SkillIncreasedMessage(Settler settler, Skill skill, SkillLevel level)
        {
            Level = level;
            Settler = settler;
            Skill = skill;
        }

        public override MessageType Type => MessageType.Settler;

        public override MessagePriority Priority =>
            Level >= SkillLevel.Expert ? MessagePriority.Uncommon : MessagePriority.Common;
        public Settler Settler { get; }
        public Skill Skill { get; }
        public SkillLevel Level { get; }
        public override string Contents => $"{Settler.Name} has become a {Level} {Skill}!";
    }
}