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
    
    public partial class Character
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int RaceId { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public int AlignmentId { get; set; }
    
        public virtual Alignment Alignment { get; set; }
        public virtual Race Race { get; set; }
    }
}
