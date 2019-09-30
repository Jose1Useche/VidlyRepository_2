namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameColumnInMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE M
                  SET M.Name = 'Pay as You Go'
                  FROM MembershipTypes M
                  WHERE M.Id = 1");

            Sql(@"UPDATE M
                  SET M.Name = 'Monthly'
                  FROM MembershipTypes M
                  WHERE M.Id = 2");

            Sql(@"UPDATE M
                  SET M.Name = 'Quarterly'
                  FROM MembershipTypes M
                  WHERE M.Id = 3");

            Sql(@"UPDATE M
                  SET M.Name = 'Annual'
                  FROM MembershipTypes M
                  WHERE M.Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
