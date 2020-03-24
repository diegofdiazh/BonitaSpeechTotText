namespace BonitaSpeechTotText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class envios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Envios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPieza = c.Int(nullable: false),
                        Guia = c.String(),
                        NombreDestinatario = c.String(),
                        DireccionDestinatario = c.String(),
                        CiudadDestinatario = c.String(),
                        PaisOrigen = c.String(),
                        PaisDestino = c.String(),
                        ValorDeclarado = c.Double(nullable: false),
                        PesoFisico = c.Double(nullable: false),
                        Telefono = c.String(),
                        PosicionArancela = c.String(),
                        Producto = c.String(),
                        TipoServicio = c.String(),
                        EstadoFisico = c.String(),
                        NumeroReserva = c.String(),
                        NombreRemitente = c.String(),
                        CiudadRemitente = c.String(),
                        DireccionRemitente = c.String(),
                        PropuestaValor = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turnoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPiezas = c.Int(nullable: false),
                        IdCamion = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Turnoes");
            DropTable("dbo.Envios");
        }
    }
}
