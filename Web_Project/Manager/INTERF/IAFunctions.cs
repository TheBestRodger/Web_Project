using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Project.Storage.Entity;

namespace Web_Project.Manager.INTERF
{
   public interface IAFunctions
    {
        IEnumerable<Functions> Functions { get;}
        IEnumerable<Functions> getLatFunctions { get; }
        IEnumerable<Functions> MathCat { get; }
        IEnumerable<Functions> PhyCat { get; }
        Functions getFun(int funId);
    }
}
