using System.Collections.Generic;

namespace CampaignManager.Web.Models.DTO
{
    public class AlignmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class CharacterClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public IEnumerable<CharacterClass> CharacterClasses { get; set; }
    }
}