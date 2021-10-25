using Hepsiburada_Case_Study.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada_Case_Study.Entity
{
    public class Plateau
    {
        public int xAxis { get; private set; }
        public int yAxis { get; private set; }
        public Plateau(int xAxis, int yAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }

    }

    
    
}
