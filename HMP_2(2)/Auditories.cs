using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMP_2_2_
{
    internal interface Auditories
    {
        int Number { get; }
        List <List<bool>> Emploimend { get; set;  }
        
    }
}
