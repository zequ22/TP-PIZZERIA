namespace CONTEXTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CLIENTEs",
                c => new
                    {
                        CODIGO = c.Int(nullable: false, identity: true),
                        NOMBRE = c.String(),
                        APELLIDO = c.String(),
                        EMAIL = c.String(),
                        DIRECCION = c.String(),
                        TEL = c.Int(nullable: false),
                        CONTRASENIA = c.String(),
                        DNI = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CODIGO);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CLIENTEs");
        }
    }
}
