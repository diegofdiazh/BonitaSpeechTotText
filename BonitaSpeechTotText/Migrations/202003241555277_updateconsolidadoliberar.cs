namespace BonitaSpeechTotText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateconsolidadoliberar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Camions", "Liberar", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Camions", "Liberar", c => c.String());
        }
    }
}
