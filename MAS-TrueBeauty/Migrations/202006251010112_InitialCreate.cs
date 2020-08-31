namespace MAS_TrueBeauty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Osobas", "czyBylaWizyta", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Osobas", "czyBylaWizyta");
        }
    }
}
