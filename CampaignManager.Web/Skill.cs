//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CampaignManager.Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class Skill
    {
        public Skill()
        {
            this.ClassSkills = new HashSet<ClassSkill>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ability { get; set; }
        public Nullable<bool> Untrained { get; set; }
        public Nullable<bool> ArmorCheckPenalty { get; set; }
        public string Description { get; set; }
        public string DescriptionFormatted { get; set; }
        public string Source { get; set; }
    
        public virtual ICollection<ClassSkill> ClassSkills { get; set; }
    }
}
