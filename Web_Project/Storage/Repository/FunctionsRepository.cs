using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Manager.INTERF;
using Web_Project.Storage.Entity;

namespace Web_Project.Storage.Repository
{
    public class FunctionsRepository : IAFunctions
    {
        private readonly AppDBContent appDBContent;
        public FunctionsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Functions> Functions => appDBContent.Functions.Include(c => c.Category);

        public IEnumerable<Functions> getLatFunctions => appDBContent.Functions.Where(p => p.isFavor).Include(c => c.Category);

        public IEnumerable<Functions> MathCat => appDBContent.Functions.Where(p => p.CaregoryId == 1).Include(c => c.Category);
        public IEnumerable<Functions> PhyCat => appDBContent.Functions.Where(p => p.CaregoryId == 2).Include(c => c.Category);
        public Functions getFun(int funId) => appDBContent.Functions.FirstOrDefault(p => p.id == funId);
    }
}
