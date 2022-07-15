namespace CONTEXTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeraversion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CLIENTEs", "APELLIDO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CLIENTEs", "APELLIDO", c => c.String());
        }
    }
}
