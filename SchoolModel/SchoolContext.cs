namespace SchoolModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SchoolContext : DbContext
    {

        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
    }
}