namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSlide : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slides", "DisplayOrder", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slides", "DisplayOrder", c => c.String(maxLength: 256));
        }
    }
}
