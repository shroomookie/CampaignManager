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
    
    public partial class AlignmentsCharacterClass
    {
        public int Id { get; set; }
        public int CharacterClassId { get; set; }
        public int AlignmentId { get; set; }
    
        public virtual Alignment Alignment { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }
    }
}
