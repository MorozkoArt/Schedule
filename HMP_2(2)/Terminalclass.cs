using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMP_2_2_
{
    internal class Terminalclass: Auditories
    {
        public int Number { get; }
        public List<List<bool>> Emploimend { get; set; }

        public Terminalclass(int Number)
        {
            this.Number = Number;
            this.Emploimend = new List<List<bool>>();
            for (int j = 0; j < Program.day_week; j++)
            {
                List<bool> list = new List<bool>();
                this.Emploimend.Add(list);
                for (int k = 0; k < Program.day_subject; k++)
                {
                    this.Emploimend[j].Add(false);
                }
            }
        }
    }
}
