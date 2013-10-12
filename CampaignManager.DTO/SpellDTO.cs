using System.Collections.Generic;

namespace CampaignManager.DTO
{
    public class SpellDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public string SubSchool { get; set; }
        public string Descriptor { get; set; }
        public string CastingTime { get; set; }
        public string Components { get; set; }
        public string Range { get; set; }
        public string Area { get; set; }
        public string Effect { get; set; }
        public string Target { get; set; }
        public string Duration { get; set; }
        public string SavingThrow { get; set; }
        public string SpellResistance { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string DescriptionFormatted { get; set; }
        public string Source { get; set; }
        public bool Hidden { get; set; }

        public class Level
        {
            public string CharacterClass { get; set; }
            public int SpellLevel { get; set; }
        }

        public IEnumerable<Level> Levels { get; set; }
    }
}