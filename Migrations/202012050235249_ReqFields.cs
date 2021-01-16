namespace TicketFinalSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReqFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ticket", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Ticket", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Ticket", "RequestDesc", c => c.String(nullable: false));
            AlterColumn("dbo.Ticket", "Note", c => c.String(nullable: false));
            AlterColumn("dbo.Ticket", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ticket", "Status", c => c.String());
            AlterColumn("dbo.Ticket", "Note", c => c.String());
            AlterColumn("dbo.Ticket", "RequestDesc", c => c.String());
            AlterColumn("dbo.Ticket", "LastName", c => c.String());
            AlterColumn("dbo.Ticket", "FirstName", c => c.String());
        }
    }
}
