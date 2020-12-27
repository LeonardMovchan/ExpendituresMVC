namespace ExpendituresDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpendituresDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "ExpenditureDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "ExpenditureDate");
        }
    }
}
