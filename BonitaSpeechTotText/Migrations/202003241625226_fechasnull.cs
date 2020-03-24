namespace BonitaSpeechTotText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechasnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Camions", "FechaDespacho", c => c.DateTime());
            AlterColumn("dbo.Camions", "FechaCierre", c => c.DateTime());
            AlterColumn("dbo.Piezas", "FechaDespacho", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Piezas", "FechaDespacho", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Camions", "FechaCierre", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Camions", "FechaDespacho", c => c.DateTime(nullable: false));
        }
    }
}
