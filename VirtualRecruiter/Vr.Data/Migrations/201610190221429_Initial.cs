namespace Vr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Description = c.String(),
                        CompanyId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(nullable: false),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.HiringResourceSkills",
                c => new
                    {
                        HiringResource_PersonId = c.Int(nullable: false),
                        Skill_SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HiringResource_PersonId, t.Skill_SkillId })
                .ForeignKey("dbo.People", t => t.HiringResource_PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Skill_SkillId, cascadeDelete: true)
                .Index(t => t.HiringResource_PersonId)
                .Index(t => t.Skill_SkillId);
            
            CreateTable(
                "dbo.EngineerSkills",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.SkillId })
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EngineerSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.EngineerSkills", "PersonId", "dbo.People");
            DropForeignKey("dbo.HiringResourceSkills", "Skill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.HiringResourceSkills", "HiringResource_PersonId", "dbo.People");
            DropForeignKey("dbo.People", "CompanyId", "dbo.Companies");
            DropIndex("dbo.EngineerSkills", new[] { "SkillId" });
            DropIndex("dbo.EngineerSkills", new[] { "PersonId" });
            DropIndex("dbo.HiringResourceSkills", new[] { "Skill_SkillId" });
            DropIndex("dbo.HiringResourceSkills", new[] { "HiringResource_PersonId" });
            DropIndex("dbo.People", new[] { "CompanyId" });
            DropTable("dbo.EngineerSkills");
            DropTable("dbo.HiringResourceSkills");
            DropTable("dbo.Skills");
            DropTable("dbo.People");
            DropTable("dbo.Companies");
        }
    }
}
