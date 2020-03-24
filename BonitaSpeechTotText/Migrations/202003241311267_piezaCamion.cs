namespace BonitaSpeechTotText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class piezaCamion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Camions", "FechaDespacho", c => c.DateTime(nullable: false));
            AddColumn("dbo.Camions", "FechaCierre", c => c.DateTime(nullable: false));
            AddColumn("dbo.Piezas", "FechaDespacho", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Piezas", "FechaDespacho");
            DropColumn("dbo.Camions", "FechaCierre");
            DropColumn("dbo.Camions", "FechaDespacho");
        }
    }
}
