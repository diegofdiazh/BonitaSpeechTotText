namespace BonitaSpeechTotText.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consolidado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PiezaCamions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CamionId = c.Int(nullable: false),
                        PiezaId = c.Int(nullable: false),
                        BodegaDestino = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Camions", "AperturarBodega", c => c.Boolean(nullable: false));
            AddColumn("dbo.Piezas", "TipoServicio", c => c.String());
            AddColumn("dbo.Piezas", "Consolidada", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Piezas", "Consolidada");
            DropColumn("dbo.Piezas", "TipoServicio");
            DropColumn("dbo.Camions", "AperturarBodega");
            DropTable("dbo.PiezaCamions");
        }
    }
}
