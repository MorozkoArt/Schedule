using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMP_2_2_
{
    internal class Schedule_generator
    {
        private List<Lectoriy> lectoriys;
        private List<Terminalclass> terminalclasses;
        private List<Group> groups;
        private int count_sub_group_day;
        public Schedule_generator(List<Lectoriy> lectoriys, List<Terminalclass> terminalclasses, List<Group> groups, int count_sub_group_day) 
        { 
            this.lectoriys = lectoriys;
            this.terminalclasses = terminalclasses;
            this.groups = groups;
            this.count_sub_group_day = count_sub_group_day;
        }
        public void Generation()
        {
            for (int i = 0; i < Program.day_week; i++)
            {
                for(int y = 0; y < groups.Count; y++)
                {
                    groups[y].max_sub_day = count_sub_group_day;
                }                    
                for (int j = 0; j < Program.day_subject; j++)
                {
                    Generation_TimeSabject(i, j);
                }
            }
        }
        public void Generation_TimeSabject(int i, int j)
        {
            int chec_subject = 0;
            for (int s = 0; s < groups.Count; s++)
            {
                if (groups[s].day_var == i)
                {
                    groups[s].schedule[i][j] = new Tuple<Subject, string>(groups[s].var_sabject, "Военная кафедра");
                }
                else if (groups[s].subjects.Count != 0 && groups[s].max_sub_day > 0)
                {
                    for (int g = 0; g < groups[s].subjects.Count; g++)
                    {
                        if (groups[s].subjects[g].type == "Лекция")
                        {                          
                            for (int s1 = 0; s1 < groups.Count; s1++)
                            {
                                if (groups[s].subjects[g] == groups[s1].schedule[i][j].Item1) chec_subject++;
                            }
                            if (chec_subject == 0)
                            {
                                for (int x = 0; x < lectoriys.Count; x++)
                                {
                                    if (lectoriys[x].Emploimend[i][j] == false)
                                    {
                                        groups[s].schedule[i][j] = new Tuple<Subject, string>(groups[s].subjects[g], "Лекторий - " + (x + 1).ToString());
                                        lectoriys[x].Emploimend[i][j] = true;
                                        groups[s].subjects.RemoveAt(g);
                                        groups[s].max_sub_day--;
                                        break;
                                    }
                                }
                            }                           
                        }
                        else if (groups[s].subjects[g].type == "Практика")
                        {
                            for (int s2 = 0; s2 < groups.Count; s2++)
                            {
                                if (groups[s].subjects[g] == groups[s2].schedule[i][j].Item1) chec_subject++;
                            }
                            if(chec_subject == 0)
                            {
                                for (int x1 = 0; x1 < terminalclasses.Count; x1++)
                                {
                                    if (terminalclasses[x1].Emploimend[i][j] == false)
                                    {
                                        groups[s].schedule[i][j] = new Tuple<Subject, string>(groups[s].subjects[g], "Терминал Класс - " + (x1 + 1).ToString());
                                        terminalclasses[x1].Emploimend[i][j] = true;
                                        groups[s].subjects.RemoveAt(g);
                                        groups[s].max_sub_day--;
                                        break;
                                    }
                                }
                            }                           
                        }
                        chec_subject = 0;
                        if (groups[s].schedule[i][j].Item1 != null) break;
                    }
                }
            }
        }
    }
}
