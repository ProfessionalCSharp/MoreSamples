namespace EntityFrameworkSequence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            Sql("CREATE SEQUENCE dbo.InvoiceSequence AS BIGINT START WITH 1000 INCREMENT BY 3 NO CACHE;");
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Long(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Invoices");
            Sql("DROP SEQUENCE dbo.InvoiceSequence");
        }
    }
}
