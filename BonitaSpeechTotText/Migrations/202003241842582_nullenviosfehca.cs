namespace BonitaSpeechTotText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullenviosfehca : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Envios", "FechaCreacion", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Envios", "FechaCreacion", c => c.DateTime(nullable: false));
        }
    }
}
