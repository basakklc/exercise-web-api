namespace WebApiDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Daires",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ad = c.String(),
                        soyad = c.String(),
                        mail_adresi = c.String(),
                        telefon = c.String(),
                        daire_no = c.String(),
                        kat_no = c.String(),
                        apart_no = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Daires");
        }
    }
}
