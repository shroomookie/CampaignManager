using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampaignManager.Web.Models.DTO
{
    public class CharacterManagerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }

        public class Race
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public IEnumerable<Race> RaceInfo { get; set; }

        public class Alignment
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string NameShort { get; set; }
        }

        public IEnumerable<Alignment> AlignmentInfo { get; set; }
    }
}