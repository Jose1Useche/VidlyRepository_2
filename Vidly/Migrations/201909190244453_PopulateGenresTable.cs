namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"Insert Into Genres (Name) Values ('Comedy')
                                                  ,('Action')
                                                  ,('Family')
                                                  ,('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
