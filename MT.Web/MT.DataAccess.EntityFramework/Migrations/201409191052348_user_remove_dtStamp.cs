namespace MT.DataAccess.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class user_remove_dtStamp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "dtStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "dtStamp", c => c.DateTime(nullable: false));
        }
    }
}
