namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatedMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre) VALUES ('Top Gun', 'Romance')");
            Sql("INSERT INTO Movies (Name, Genre) VALUES ('Shrek 1', 'Comedy')");
            Sql("INSERT INTO Movies (Name, Genre) VALUES ('Frozen', 'Cooking')");
            Sql("INSERT INTO Movies (Name, Genre) VALUES ('Wild Hogs', 'Documentary')");
            Sql("INSERT INTO Movies (Name, Genre) VALUES ('Shrek 2', 'Finance')");
            Sql("INSERT INTO Movies (Name, Genre) VALUES ('Shrek 3', 'War')");
        }
        
        public override void Down()
        {
        }
    }
}
