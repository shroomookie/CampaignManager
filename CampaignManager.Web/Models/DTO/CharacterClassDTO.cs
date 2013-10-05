using System.Collections.Generic;

namespace CampaignManager.Web.Models.DTO
{
    public class CharacterClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int HitDie { get; set; }
        public int SkillPoints { get; set; }
        public string AttackBonusType { get; set; }

        public class AttackBonusValue
        {
            public int HitDice { get; set; }
            public int Value { get; set; }
        }

        public IEnumerable<AttackBonusValue> AttackBonusValues { get; set; }

        public string FortitudeType { get; set; }
        public string ReflexType { get; set; }
        public string WillpowerType { get; set; }
        public string Source { get; set; }
        public bool Hidden { get; set; }

        public class SkillName
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public IEnumerable<SkillName> SkillNames { get; set; }
    }
}