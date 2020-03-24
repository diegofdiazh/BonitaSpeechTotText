namespace BonitaSpeechTotText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class piezasCamiones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Camions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placas = c.String(),
                        NombreConductor = c.String(),
                        Liberar = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Piezas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Guia = c.String(),
                        Manifesto = c.String(),
                        TipoPieza = c.String(),
                        CantidadEnvios = c.Int(nullable: false),
                        Aerolinea = c.String(),
                        PaisOrigen = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Piezas");
            DropTable("dbo.Camions");
        }
    }
}
