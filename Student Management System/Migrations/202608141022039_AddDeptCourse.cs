namespace Student_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeptCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCourses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.tblDepartments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            AddColumn("dbo.tblStudents", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.tblStudents", "CourseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblStudents", "CourseId");
            DropColumn("dbo.tblStudents", "DepartmentId");
            DropTable("dbo.tblDepartments");
            DropTable("dbo.tblCourses");
        }
    }
}
