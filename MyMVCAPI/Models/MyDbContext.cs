using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyMVCAPI.Models
{
        public class MyDbContext : DbContext
        {
            public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
            {

            }
            public DbSet<Student> Students { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Module> Modules { get; set; }
            public DbSet<Lecture> Lectures { get; set; }
            public DbSet<StuCou> StuCous { get; set; }
        }

    }
