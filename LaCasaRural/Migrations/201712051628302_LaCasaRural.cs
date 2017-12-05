namespace LaCasaRural.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaCasaRural : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Llogaters",
                c => new
                    {
                        IdLlogater = c.Int(nullable: false, identity: true),
                        NomLlogater = c.String(maxLength: 200),
                        CognomLlogater = c.String(),
                        CodiPostal = c.Int(nullable: false),
                        NIF = c.String(),
                    })
                .PrimaryKey(t => t.IdLlogater);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        IdReserva = c.Int(nullable: false, identity: true),
                        DataEntrada = c.DateTime(nullable: false),
                        DataSortida = c.DateTime(),
                        IdLlogater = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdReserva)
                .ForeignKey("dbo.Llogaters", t => t.IdLlogater, cascadeDelete: true)
                .Index(t => t.IdLlogater);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "IdLlogater", "dbo.Llogaters");
            DropIndex("dbo.Reservas", new[] { "IdLlogater" });
            DropTable("dbo.Reservas");
            DropTable("dbo.Llogaters");
        }
    }
}
