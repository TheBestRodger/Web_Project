using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Storage.Entity;

namespace Web_Project.Storage
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options): base(options)
        {
                
        }

        public DbSet<Functions> Functions { get; set; }
        public DbSet<Category> Category { set; get; }
        public DbSet<NewPage> PageItem { set; get; }



    }
}
