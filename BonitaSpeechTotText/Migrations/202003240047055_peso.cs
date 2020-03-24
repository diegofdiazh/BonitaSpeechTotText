namespace BonitaSpeechTotText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class peso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Piezas", "Peso", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Piezas", "Peso");
        }
    }
}
