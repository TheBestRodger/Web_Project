using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Web_Project.Storage.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; } // название
        public byte[] Picture { get; set; }
    }
    public class PictureContext : DbContext
    {
        public PictureContext()
            : base("DefaultConnection")
        { }

        public DbSet<Image> Pictures { get; set; }
    }
}