﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CampaignManagerEntities : DbContext
    {
        public CampaignManagerEntities()
            : base("name=CampaignManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Character> Characters { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Alignment> Alignments { get; set; }
        public DbSet<AlignmentsCharacterClass> AlignmentsCharacterClasses { get; set; }
        public DbSet<BaseAttackBonus> BaseAttackBonuses { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<ClassSkill> ClassSkills { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SpellLevel> SpellLevels { get; set; }
        public DbSet<Spell> Spells { get; set; }
    }
}
