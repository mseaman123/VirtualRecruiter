namespace Vr.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoRating : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skills", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Rating", c => c.Int());
        }
    }
}
