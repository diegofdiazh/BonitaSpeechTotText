namespace BonitaSpeechTotText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsRecepcionista", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsSupterminal", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsSupbodega", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsAuxdian", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsDigitador", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsDigitador");
            DropColumn("dbo.AspNetUsers", "IsAuxdian");
            DropColumn("dbo.AspNetUsers", "IsSupbodega");
            DropColumn("dbo.AspNetUsers", "IsSupterminal");
            DropColumn("dbo.AspNetUsers", "IsRecepcionista");
        }
    }
}
