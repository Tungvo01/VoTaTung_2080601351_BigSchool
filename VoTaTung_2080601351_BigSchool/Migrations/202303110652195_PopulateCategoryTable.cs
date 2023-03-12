namespace VoTaTung_2080601351_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into categories (Id, name) values (1, 'Development')");
            Sql("Insert into categories (Id, name) values (2, 'Business')");
            Sql("Insert into categories (Id, name) values (3, 'Maketing')");
        }
        
        public override void Down()
        {
        }
    }
}
